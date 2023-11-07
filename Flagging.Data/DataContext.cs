using Microsoft.EntityFrameworkCore;

namespace Flagging.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Flag> Flags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Flagging;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Flag>()
                .HasKey(fi => fi.Id);

            modelBuilder.Entity<Flag>()
                .HasOne(fi => fi.Article)
                .WithMany(a => a.ReportFlags)
                .HasForeignKey(fi => fi.ItemId)
                .HasPrincipalKey(a => a.Id);

            modelBuilder.Entity<Flag>()
                .HasOne(fi => fi.Comment)
                .WithMany(c => c.ReportFlags)
                .HasForeignKey(fi => fi.ItemId)
                .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<Flag>()
                .HasOne(fi => fi.ReportedUser)
                .WithMany(u => u.ReportFlags)
                .HasForeignKey(fi => fi.ItemId)
                .HasPrincipalKey(u => u.Id);

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(UsersSeed());
            modelBuilder.Entity<Article>().HasData(ArticleSeed());
            modelBuilder.Entity<Comment>().HasData(CommentSeed());
            modelBuilder.Entity<Flag>().HasData(FlagSeed());
        }

        private IEnumerable<Comment> CommentSeed()
        {
            for (var i = 1; i <= 25; i++)
            {
                yield return new Comment
                {
                    Id = i,
                    UserId = i,
                    Message = Faker.Lorem.Sentence(5)
                };
            }
        }

        private IEnumerable<Article> ArticleSeed()
        {
            for (var i = 1; i <= 25; i++)
            {
                yield return new Article
                {
                    Id = i,
                    UserId = i,
                    Description = Faker.Lorem.Paragraph(5)
                };
            }
        }

        private IEnumerable<User> UsersSeed()
        {
            for (var i = 1; i <= 25; i++)
            {
                yield return new User
                {
                    Id = i,
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last()
                };
            }
        }

        private IEnumerable<Flag> FlagSeed()
        {
            var j = 1;

            for (var i = 1; i <= 25; i++)
            {
                for (var z = 0; z < Faker.RandomNumber.Next(5); z++)
                {
                    yield return new Flag
                    {
                        Id = j++,
                        ItemId = i,
                        Type = FlaggedContentType.Article,
                        DateCreated = Faker.Identification.DateOfBirth(),
                    };
                }
            }

            for (var i = 1; i <= 25; i++)
            {
                for (var z = 0; z < Faker.RandomNumber.Next(5); z++)
                {
                    yield return new Flag
                    {
                        Id = j++,
                        ItemId = i,
                        Type = FlaggedContentType.Comment,
                        DateCreated = Faker.Identification.DateOfBirth(),
                    };
                }
            }

            for (var i = 1; i <= 25; i++)
            {
                for (var z = 0; z<Faker.RandomNumber.Next(5); z++)
                {
                    yield return new Flag
                    {
                        Id = j++,
                        ItemId = i,
                        Type = FlaggedContentType.Member,
                        DateCreated = Faker.Identification.DateOfBirth(),
                    };
                }
            }
        }
    }
}
