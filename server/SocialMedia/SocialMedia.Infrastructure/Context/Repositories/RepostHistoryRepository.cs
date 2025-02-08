using SocialMedia.Domain.Entity;
using SocialMedia.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Context.Repositories
{
    public class RepostHistoryRepository : RepositoryBase<RepostHistory>, IRepostHistoryRepository
    {
        public RepostHistoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
