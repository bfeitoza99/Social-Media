using SocialMedia.Domain.Entities;


namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IRepostHistoryService
    {
        Task AddAsync(RepostHistory entity);

        Task<RepostHistory> FindRepostHistoryByUserAndPostAsync(int userId, int postId);
    }
}
