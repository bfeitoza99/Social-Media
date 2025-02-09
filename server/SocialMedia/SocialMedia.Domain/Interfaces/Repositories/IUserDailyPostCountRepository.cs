
using SocialMedia.Domain.Entity;

namespace SocialMedia.Domain.Interfaces.Repositories
{
    public interface IUserDailyPostCountRepository : IRepositoryBase<UserDailyPostCount>
    {
        Task<UserDailyPostCount> FindUserPostCountByReferenceDateAsync(int userId, DateOnly date);

        Task UpsertAsync(int userId, DateOnly date);
    }
}
