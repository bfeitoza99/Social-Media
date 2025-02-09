using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Interfaces.Repositories;



namespace SocialMedia.Infrastructure.Context.Repositories
{
    public class UserDailyPostCountRepository : RepositoryBase<UserDailyPostCount>, IUserDailyPostCountRepository
    {
        private readonly AppDbContext _context;
        public UserDailyPostCountRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<UserDailyPostCount> FindUserPostCountByReferenceDateAsync(int userId, DateOnly date)
        {
            return await _context.UserDailyPostCounts.FirstOrDefaultAsync(x => x.UserId == userId && x.ReferenceDate == date);
        }

        public async Task UpsertAsync(int userId, DateOnly date)
        {
            await _context.UserDailyPostCounts.Upsert(new UserDailyPostCount
            {
                UserId = userId,
                ReferenceDate = date,
                PostCount = 1
            }).On(x => new { x.UserId, x.ReferenceDate }) 
            .WhenMatched((old, newEntity) => new UserDailyPostCount
            {
                PostCount = old.PostCount + 1 
            })
            .RunAsync();
        }
    }
}
