using SocialMedia.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IRepostHistoryService
    {
        Task AddAsync(RepostHistory entity);

        Task<RepostHistory> FindRepostHistoryByUserAndPostAsync(int userId, int postId);
    }
}
