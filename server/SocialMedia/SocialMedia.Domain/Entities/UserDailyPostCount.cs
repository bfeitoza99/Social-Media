
namespace SocialMedia.Domain.Entities
{
    public class UserDailyPostCount
    {       
        public int UserId { get; set; }
        public int PostCount { get; set; } = 0;
        public DateOnly ReferenceDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
