using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entity;
using SocialMedia.Domain.Interfaces.Repositories;



namespace SocialMedia.Infrastructure.Context.Repositories
{
    public class UserDailyPostLimitRepository : RepositoryBase<UserDailyPostLimit>, IUserDailyPostLimitRepository
    {
        private readonly AppDbContext _context;
        public UserDailyPostLimitRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserDailyPostLimit> FindUserLimitByReferenceDateAsync(int userId, DateOnly date)
        {
            return await _context.UserDailyPostLimits.FirstOrDefaultAsync(x => x.UserId == userId && x.ReferenceDate == date);
        }

        public async Task UpsertAsync(int userId, DateOnly date)
        {
            await _context.UserDailyPostLimits.Upsert(new UserDailyPostLimit
            {
                UserId = userId,
                ReferenceDate = date,
                PostCount = 1
            }).On(x => new { x.UserId, x.ReferenceDate }) 
            .WhenMatched((old, newEntity) => new UserDailyPostLimit
            {
                PostCount = old.PostCount + 1 
            })
            .RunAsync();
        }
    }
}
