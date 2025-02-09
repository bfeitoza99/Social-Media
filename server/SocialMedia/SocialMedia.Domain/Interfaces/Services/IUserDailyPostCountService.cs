using SocialMedia.Domain.Entities;


namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IUserDailyPostCountService
    {
        Task<UserDailyPostCount> FindUserLimitByReferenceDateAsync(int userId, DateOnly date);

        Task UpsertAsync(int userId, DateOnly date);
    }
}
