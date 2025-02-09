
namespace SocialMedia.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string ProfileImageUrl{ get; set; }

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
        public virtual ICollection<UserDailyPostCount> DailyPostCounts { get; set; } = new List<UserDailyPostCount>();

        public User()
        {

        }
    }
}
