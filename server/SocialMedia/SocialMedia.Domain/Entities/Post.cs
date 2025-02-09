
namespace SocialMedia.Domain.Entities
{
    public class Post
    {
        public int Id { get;  set; } 
        public string Content { get;  set; }      
        public int AuthorUserId { get;  set; }
        public DateTime CreatedAt { get; set; }
        public int RepostCount { get;  set; } = 0;
        public bool IsRepost { get;  set; } = false;
        public int? OriginalPostId { get;  set; }

        public virtual Post? OriginalPost { get; set; }
        public virtual User User { get; set; }

        public Post()
        {
        }

        public void IncrementRepost()
        {
            RepostCount++;
        }
    }
}
