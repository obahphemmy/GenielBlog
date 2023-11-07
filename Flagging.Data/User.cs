using System.ComponentModel.DataAnnotations;

namespace Flagging.Data
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<Flag> ReportFlags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
    }
}