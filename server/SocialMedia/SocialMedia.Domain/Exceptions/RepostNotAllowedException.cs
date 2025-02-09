

namespace SocialMedia.Domain.Exceptions
{
    public class RepostNotAllowedException : BusinessException
    {
        public RepostNotAllowedException() : base("User has already reposted this post and cannot repost it again.")
        {
        }
    }

}
