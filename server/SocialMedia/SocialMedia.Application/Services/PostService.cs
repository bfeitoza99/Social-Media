using MediatR;
using SocialMedia.Application.Events;
using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Exceptions;
using SocialMedia.Domain.Interfaces.Factories;
using SocialMedia.Domain.Interfaces.Repositories;
using SocialMedia.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;


namespace SocialMedia.Application.Services
{
    public class PostService: IPostService
    {
        private readonly IUserDailyPostCountService _userDailyPostLimitService;
        private readonly IPostRepository _postRepository;
        private readonly IRepostHistoryService _repostHistoryService;
        private readonly IMediator _mediator;
        private readonly IPostFactory _postFactory;


        private readonly DateOnly _currentDate = DateOnly.FromDateTime(DateTime.UtcNow);


        private readonly int _dailyPostLimit;

        private string _keyword;
        private string _orderBy;
        private int _page;
        private int _pageSize;

        public PostService(IUserDailyPostCountService userDailyPostLimitService, 
            IPostRepository postRepository, 
            IRepostHistoryService repostHistoryService,
            IMediator mediator,
            IPostFactory postFactory)
        {
            _userDailyPostLimitService = userDailyPostLimitService;
            _postRepository = postRepository;
            _repostHistoryService = repostHistoryService;
            _mediator = mediator;
            _dailyPostLimit = 5;
            _postFactory = postFactory;
        }

        public async Task AddPostAsync(CreatePostDTO createPostDTO)
        {
            await ValidateDailyPostLimit(createPostDTO.AuthorUserId);

            await _postRepository.AddAsync(_postFactory.CreatePost(createPostDTO));

            await _mediator.Publish(new UpdateDailyPostCountEvent(createPostDTO.AuthorUserId, _currentDate));
        }     

        public async Task AddRepostAsync(int originalPostId, CreateRepostDTO repostDTO)
        {
            await ValidateDailyPostLimit(repostDTO.AuthorUserId);
            await ValidateRepost(originalPostId , repostDTO);

            await _postRepository.AddAsync(_postFactory.CreateRepost(originalPostId, repostDTO));

            await PublishRepostEvents(originalPostId, repostDTO.AuthorUserId);

        }
       
        private async Task PublishRepostEvents(int originalPostId, int userId)
        {
            await _mediator.Publish(new UpdateDailyPostCountEvent(userId, _currentDate));
            await _mediator.Publish(new UpdateRepostCountEvent(originalPostId));
            await _mediator.Publish(new UpdateRepostHistoryEvent(userId, originalPostId));
        }

        private async Task ValidateRepost(int originalPostId,  CreateRepostDTO repostDTO)
        {
            var existedRepost = await _repostHistoryService.FindRepostHistoryByUserAndPostAsync(repostDTO.AuthorUserId, originalPostId);

            if (existedRepost != null)
            {
                throw new RepostNotAllowedException();
            }
        }

        private async Task<UserDailyPostCount> FindDailyPostLimit(int userAuthorId)
        {
            return await _userDailyPostLimitService.FindUserLimitByReferenceDateAsync(userAuthorId, _currentDate);
        }

        private async Task ValidateDailyPostLimit(int userId)
        {
            var userDailyLimit = await FindDailyPostLimit(userId);

            if (userDailyLimit != null && userDailyLimit.PostCount >= _dailyPostLimit)
            {
                throw new DailyPostLimitExceededException();
            }
        }


        public IPostService SetKeyword(string keyword)
        {
            _keyword = keyword;
            return this;
        }

        public IPostService SetOrderBy(string orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public IPostService SetPage(int page)
        {
            _page = page;
            return this;
        }

        public IPostService SetPageSize(int pageSize)
        {
            _pageSize = pageSize;
            return this;
        }

        public async Task<PaginatedResult<PostResponseDTO>> FindPostsAsync()
        {
            var posts =  _postRepository.FindAllPosts();
         
            if (!string.IsNullOrEmpty(_keyword))
            {
                posts = posts.Where(p => p.Content.Contains(_keyword));
            }

            if (_orderBy == "trending")
            {
                posts = posts.OrderByDescending(p => p.RepostCount);
            }
            else
            {
                posts = posts.OrderByDescending(p => p.CreatedAt);
            }

            var totalPosts = await posts.CountAsync();

            var pagedPosts = await posts
                .Skip((_page - 1) * _pageSize)
                .Take(_pageSize)
                .Select(p => new PostResponseDTO
                {
                    Id = p.Id,
                    Content = p.Content,
                    AuthorNickname = p.User.Nickname,
                    AuthorProfileImageUrl = p.User.ProfileImageUrl,
                    AuthorUserId = p.User.Id,
                    CreatedAt = p.CreatedAt,
                    RepostCount = p.RepostCount,
                    IsRepost = p.IsRepost,
                    OriginalPost = p.OriginalPostId.HasValue ? new OriginalPostDTO
                    {
                        Id = p.OriginalPost.Id,
                        Content = p.OriginalPost.Content,
                        AuthorNickname = p.OriginalPost.User.Nickname,
                        AuthorProfileImageUrl = p.OriginalPost.User.ProfileImageUrl,
                        AuthorUserId = p.OriginalPost.User.Id,
                        CreatedAt = p.OriginalPost.CreatedAt,
                        RepostCount = p.OriginalPost.RepostCount,
                        IsRepost = false
                    } : null
                }).ToListAsync();


            return new PaginatedResult<PostResponseDTO>
            {
                Items = pagedPosts,
                TotalCount = totalPosts,
                Page = _page,
                PageSize = _pageSize
            };
        }

    }
}
