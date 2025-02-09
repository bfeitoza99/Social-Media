using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Interfaces.Repositories;

namespace SocialMedia.Infrastructure.Context.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
    }
}
