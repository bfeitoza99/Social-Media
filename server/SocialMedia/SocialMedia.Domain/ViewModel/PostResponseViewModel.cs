
namespace SocialMedia.Domain.DTO
{
    public class PostResponseViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorNickname { get; set; }
        public string AuthorProfileImageUrl { get; set; }
        public int AuthorUserId { get; set; }
        public DateTime CreatedAt { get; set; } 
        public int RepostCount { get; set; } = 0;
        public bool IsRepost { get; set; } = false;
        public OriginalPostViewModel? OriginalPost {  get; set; }

    }


    public class OriginalPostViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string AuthorNickname { get; set; }
        public string AuthorProfileImageUrl { get; set; }
        public int AuthorUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public int RepostCount { get; set; } = 0;
        public bool IsRepost { get; set; } = false;
    }
}
