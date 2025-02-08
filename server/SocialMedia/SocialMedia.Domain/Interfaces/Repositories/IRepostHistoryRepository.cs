using SocialMedia.Domain.Entity;

namespace SocialMedia.Domain.Interfaces.Repositories
{
    public interface IRepostHistoryRepository : IRepositoryBase<RepostHistory>
    {
        Task<RepostHistory> FindRepostHistoryByUserAndPostAsync(int userId, int postId);
    }
}
