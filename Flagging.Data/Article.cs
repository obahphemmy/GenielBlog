namespace Flagging.Data
{
    public class Article
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }
        public virtual ICollection<Flag> ReportFlags { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}