
namespace SocialMedia.Domain.Exceptions
{
    public class DailyPostLimitExceededException : BusinessException
    {
        public DailyPostLimitExceededException() : base("User has reached the daily post limit.")
        {
        }
    }
}
