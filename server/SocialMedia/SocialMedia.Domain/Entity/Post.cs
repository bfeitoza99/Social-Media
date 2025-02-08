
namespace SocialMedia.Domain.Entity
{
    public class Post
    {
        public int Id { get;  set; } 
        public string Content { get;  set; }
        public string AuthorUsername { get;  set; }
        public int AuthorUserId { get;  set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow.Date;
        public int RepostCount { get;  set; } = 0;
        public bool IsRepost { get;  set; } = false;
        public int? OriginalPostId { get;  set; }

        private Post()
        {
        }
    }
}
