
namespace SocialMedia.Domain.Entity
{
    public class UserDailyPostLimit
    {
        public int Id { get; set; }  
        public int UserId { get; set; }
        public int PostCount { get; set; } = 0;
        public DateOnly ReferenceDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
