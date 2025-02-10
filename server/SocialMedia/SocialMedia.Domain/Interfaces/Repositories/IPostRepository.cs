using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Interfaces.Services;


namespace SocialMedia.Domain.Interfaces.Repositories
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        IQueryable<Post> FindAllPosts();
        Task IncrementRepostCountAsync(int postId); 
   

    }
}
