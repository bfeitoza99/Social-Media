using SocialMedia.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IUserDailyPostLimitService
    {
        Task<UserDailyPostLimit> FindUserLimitByReferenceDateAsync(int userId, DateOnly date);

        Task UpsertAsync(int userId, DateOnly date);
    }
}
