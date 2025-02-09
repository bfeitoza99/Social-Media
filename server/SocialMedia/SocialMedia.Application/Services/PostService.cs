using MediatR;
using SocialMedia.Application.Events;
using SocialMedia.Domain.DTO;
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
        private readonly IMediator _mediator;
        private readonly DateOnly _currentDate = DateOnly.FromDateTime(DateTime.UtcNow);


        private readonly int _dailyPostLimit;

        public PostService(IUserDailyPostLimitService userDailyPostLimitService, 
            IPostRepository postRepository, 
            IRepostHistoryService repostHistoryService,
            IMediator mediator)
        {
            _userDailyPostLimitService = userDailyPostLimitService;
            _postRepository = postRepository;
            _repostHistoryService = repostHistoryService;
            _mediator = mediator;
            _dailyPostLimit = 5;
        }

        public async Task AddPostAsync(CreatePostDTO createPostDTO)
        {
            var userDailyLimit = await FindDailyPostLimit(createPostDTO.AuthorUserId);

            if (userDailyLimit != null && userDailyLimit.PostCount >= _dailyPostLimit)
            {
                return;
            }

            await _postRepository.AddAsync(new Post
            {
                AuthorNickname = createPostDTO.AuthorNickname,
                AuthorUserId = createPostDTO.AuthorUserId,
                Content = createPostDTO.Content,          
            });

            await _mediator.Publish(new UpdateDailyPostLimitEvent(createPostDTO.AuthorUserId, _currentDate));           
        }


        public async Task AddRepostAsync(RepostDTO repostDTO)
        {            
            var userDailyLimit = await FindDailyPostLimit(repostDTO.AuthorUserId);

            if (userDailyLimit != null && userDailyLimit.PostCount >= 5)
            {
                return;
            }

            var existedRepost = await _repostHistoryService.FindRepostHistoryByUserAndPostAsync(repostDTO.AuthorUserId, repostDTO.OriginalPostId);

            if (existedRepost != null)
            {
                return;
            }

            await _postRepository.AddAsync(new Post
            {
                AuthorNickname = "@AliceJohnson",
                AuthorUserId = repostDTO.AuthorUserId,
                Content = "Joe Doe",
                IsRepost = true,
                OriginalPostId = repostDTO.OriginalPostId,
            });

            await PublishRepostEvents(repostDTO.OriginalPostId, repostDTO.AuthorUserId);

        }

        private async Task<UserDailyPostLimit> FindDailyPostLimit(int  userAuthorId)
        {           
            return await _userDailyPostLimitService.FindUserLimitByReferenceDateAsync(userAuthorId, _currentDate);
        }

        private async Task PublishRepostEvents(int originalPostId, int userId)
        {
            await _mediator.Publish(new UpdateDailyPostLimitEvent(2, _currentDate));
            await _mediator.Publish(new UpdateRepostCountEvent(originalPostId));
            await _mediator.Publish(new UpdateRepostHistoryEvent(userId, originalPostId));
        }
    }
}
