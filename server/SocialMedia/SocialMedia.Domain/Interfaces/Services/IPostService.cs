using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Interfaces.Repositories;

namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IPostService : IPaginateService<IPostService>
    {

        Task AddPostAsync(CreatePostDTO createPostDTO);


        Task AddRepostAsync(int originalPostId, CreateRepostDTO repostDTO);

        Task<PaginatedResult<PostResponseDTO>> FindPostsAsync();

        IPostService SetKeyword(string keyword);

    }
}
