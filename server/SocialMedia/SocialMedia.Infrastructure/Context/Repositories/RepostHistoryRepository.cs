using Microsoft.EntityFrameworkCore;
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

        private readonly AppDbContext _context;
        public RepostHistoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<RepostHistory> FindRepostHistoryByUserAndPostAsync(int userId, int postId)
        {
            return await _context.RepostHistories.FirstOrDefaultAsync(x => x.UserId == userId && x.PostId == postId);
        }

    }
}
