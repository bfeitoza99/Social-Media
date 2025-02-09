namespace SocialMedia.Domain.Entities
{
    public class RepostHistory
    {    
        public int UserId { get; set; } 
        public int PostId { get; set; } 
        public DateTime RepostDate { get; set; } = DateTime.UtcNow;
    }
}
