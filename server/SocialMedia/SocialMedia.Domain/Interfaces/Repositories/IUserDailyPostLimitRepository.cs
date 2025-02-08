
using SocialMedia.Domain.Entity;

namespace SocialMedia.Domain.Interfaces.Repositories
{
    public interface IUserDailyPostLimitRepository : IRepositoryBase<UserDailyPostLimit>
    {
        Task<UserDailyPostLimit> FindUserLimitByReferenceDateAsync(int userId, DateOnly date);

        Task UpsertAsync(int userId, DateOnly date);
    }
}
