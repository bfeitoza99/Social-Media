using SocialMedia.Domain.Entity;
using SocialMedia.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Context.Repositories
{
    public class UserDailyPostLimitRepository : RepositoryBase<UserDailyPostLimit>, IUserDailyPostLimitRepository
    {
        public UserDailyPostLimitRepository(AppDbContext context) : base(context)
        {
        }
    }
}
