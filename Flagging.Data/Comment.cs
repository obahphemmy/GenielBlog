using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flagging.Data
{
    public class Comment
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [MaxLength]
        public string Message { get; set; }
        public virtual ICollection<Flag> ReportFlags { get; set; }

        public virtual User User { get; set; }
    }
}