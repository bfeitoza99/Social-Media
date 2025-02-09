using SocialMedia.Domain.Entities;


namespace SocialMedia.Domain.Interfaces.Repositories
{
    public interface IPostRepository : IRepositoryBase<Post>
    {
        Task IncrementRepostCountAsync(int postId);
    }
}
