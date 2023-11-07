using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flagging.Data
{
    public class Flag
    {
        public Flag()
        {
        }

        public Flag(Article article) : this()
        {
            ItemId = article.Id;
            Article = article;
            Type = FlaggedContentType.Article;
        }

        public Flag(Comment comment) : this()
        {
            Comment = comment;
            ItemId = comment.Id;
            Type = FlaggedContentType.Comment;
        }

        public Flag(User user) : this()
        {
            ItemId = user.Id;
            ReportedUser = user;
            Type = FlaggedContentType.Member;
        }

        public int Id { get; set; }

        public int? ItemId { get; set; }

        public FlaggedContentStatus Status { get; set; }
        public FlaggedContentType Type { get; set; }
        public DateTime DateCreated { get; set; }

        public virtual User ReportedUser { get; set; }

        public virtual Article Article { get; set; }

        public virtual Comment Comment { get; set; }

        public int FlaggedItemId
        {
            get
            {
                switch (Type)
                {
                    case FlaggedContentType.Article:
                        return ItemId.Value;
                    case FlaggedContentType.Comment:
                        return ItemId.Value;
                    case FlaggedContentType.Member:
                        return ItemId.Value;
                }
                return 0;
            }
        }
    }

    public enum FlaggedContentStatus
    {
        AwaitingReview = 0,
        Resolved = 1,
        Ignored = 9
    }

    public enum FlaggedContentType
    {
        Article,
        Member,
        Comment,
    }
}
