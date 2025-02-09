using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Entities;


namespace SocialMedia.Domain.Interfaces.Repositories
{
    public interface IPostRepository : IRepositoryBase<Post>, IPaginateRepository<IPostRepository>
    {
        Task IncrementRepostCountAsync(int postId); 

        Task<PaginatedResult<PostResponseDTO>> GetPostsAsync();
    }
}
