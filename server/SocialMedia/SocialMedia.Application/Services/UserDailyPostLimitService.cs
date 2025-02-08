using SocialMedia.Domain.Entity;
using SocialMedia.Domain.Interfaces.Repositories;
using SocialMedia.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Application.Services
{
    public class UserDailyPostLimitService: IUserDailyPostLimitService
    {
        private readonly IUserDailyPostLimitRepository _userDailyPostLimitRepository;
        public UserDailyPostLimitService(IUserDailyPostLimitRepository userDailyPostLimitRepository) 
        {         
            _userDailyPostLimitRepository = userDailyPostLimitRepository;
        }

        public async Task<UserDailyPostLimit> FindUserLimitByReferenceDateAsync(int userId, DateOnly date)
        {
            return await _userDailyPostLimitRepository.FindUserLimitByReferenceDateAsync(userId, date);
        }

        public async Task UpsertAsync(int userId, DateOnly date)
        {
             await _userDailyPostLimitRepository.UpsertAsync(userId, date);
        }
    }
}
