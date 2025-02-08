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
    public class RepostHistoryService: IRepostHistoryService
    {
        private readonly IRepostHistoryRepository _repository;

        public RepostHistoryService(IRepostHistoryRepository repository)
        {
            _repository = repository;
        }


        public async Task<RepostHistory> FindRepostHistoryByUserAndPostAsync(int userId, int postId)
        {
            return await _repository.FindRepostHistoryByUserAndPostAsync(userId, postId);
        }

        public  async Task AddAsync(RepostHistory entity)
        {
            await _repository.AddAsync(entity);
        }
    }
}
