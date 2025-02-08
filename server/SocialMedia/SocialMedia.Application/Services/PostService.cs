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
    public class PostService: IPostService
    {
        private readonly IUserDailyPostLimitService _userDailyPostLimitService;
        private readonly IPostRepository _postRepository;
        private readonly IRepostHistoryService _repostHistoryService;

        public PostService(IUserDailyPostLimitService userDailyPostLimitService, 
            IPostRepository postRepository, 
            IRepostHistoryService repostHistoryService)
        {
            _userDailyPostLimitService = userDailyPostLimitService;
            _postRepository = postRepository;
            _repostHistoryService = repostHistoryService;
        }

        public async Task AddPostAsync()
        {
            var userDailyLimit = await _userDailyPostLimitService.FindUserLimitByReferenceDateAsync(1, DateOnly.FromDateTime(DateTime.Now));
            if (userDailyLimit != null && userDailyLimit.PostCount >= 5)
            {
                return;
            }

            await _postRepository.AddAsync(new Post
            {
                AuthorNickname = "@AliceJohnson",
                AuthorUserId = 2,
                Content = "Joe Doe",
                IsRepost = false,
                RepostCount = 0,
            });

            await _userDailyPostLimitService.UpsertAsync(2, DateOnly.FromDateTime(DateTime.Now));
        }


        public async Task AddRepostAsync()
        {

            int originalPostId = 1;
            int userId = 1;
            var userDailyLimit = await _userDailyPostLimitService.FindUserLimitByReferenceDateAsync(1, DateOnly.FromDateTime(DateTime.Now));
            if (userDailyLimit != null && userDailyLimit.PostCount >= 5)
            {
                return;
            }

            var existedRepost = await _repostHistoryService.FindRepostHistoryByUserAndPostAsync(userId, originalPostId);

            if(existedRepost != null)
            {
                return;
            }        

            await _postRepository.AddAsync(new Post
            {
                AuthorNickname = "@AliceJohnson",
                AuthorUserId = userId,
                Content = "Joe Doe",
                IsRepost = true,
                RepostCount = 0,
                OriginalPostId = originalPostId,
            });

            await _repostHistoryService.AddAsync(new RepostHistory
            {
                PostId = originalPostId,
                UserId = userId,
            });

            await _postRepository.IncrementRepostCountAsync(originalPostId);

            await _userDailyPostLimitService.UpsertAsync(1, DateOnly.FromDateTime(DateTime.Now));


        }

    }
}
