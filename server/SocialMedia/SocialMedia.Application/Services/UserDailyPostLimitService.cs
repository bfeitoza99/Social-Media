using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Interfaces.Repositories;
using SocialMedia.Domain.Interfaces.Services;


namespace SocialMedia.Application.Services
{
    public class UserDailyPostLimitService: IUserDailyPostCountService
    {
        private readonly IUserDailyPostCountRepository _userDailyPostLimitRepository;
        public UserDailyPostLimitService(IUserDailyPostCountRepository userDailyPostLimitRepository) 
        {         
            _userDailyPostLimitRepository = userDailyPostLimitRepository;
        }

        public async Task<UserDailyPostCount> FindUserLimitByReferenceDateAsync(int userId, DateOnly date)
        {
            return await _userDailyPostLimitRepository.FindUserPostCountByReferenceDateAsync(userId, date);
        }

        public async Task UpsertAsync(int userId, DateOnly date)
        {
             await _userDailyPostLimitRepository.UpsertAsync(userId, date);
        }
    }
}
