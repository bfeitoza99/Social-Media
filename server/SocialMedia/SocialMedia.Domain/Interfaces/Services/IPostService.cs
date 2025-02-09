using SocialMedia.Domain.DTO;

namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IPostService
    {

        Task AddPostAsync(CreatePostDTO createPostDTO);


        Task AddRepostAsync(RepostDTO repostDTO);
     
    }
}
