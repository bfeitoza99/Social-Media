using System.ComponentModel.DataAnnotations;

namespace SocialMedia.Domain.DTO
{
    public class CreatePostDTO
    {
       
        public string Content { get; set; }               
        public int AuthorUserId { get; set; }
    }
}
