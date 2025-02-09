
namespace SocialMedia.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Name { get; set; }
        public string ProfileImageUrl{ get; set; }

        public User()
        {

        }
    }
}
