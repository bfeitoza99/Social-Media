using Moq;
using MediatR;
using SocialMedia.Application.Services;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Exceptions;
using SocialMedia.Domain.Interfaces.Factories;
using SocialMedia.Domain.Interfaces.Repositories;
using SocialMedia.Domain.Interfaces.Services;
using SocialMedia.Application.Events;


namespace SocialMedia.Tests.Services
{
    public class PostServiceTests
    {
        private readonly Mock<IUserDailyPostCountService> _userDailyPostLimitServiceMock;
        private readonly Mock<IPostRepository> _postRepositoryMock;
        private readonly Mock<IRepostHistoryService> _repostHistoryServiceMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IPostFactory> _postFactoryMock;
        private readonly PostService _postService;

        public PostServiceTests()
        {
            _userDailyPostLimitServiceMock = new Mock<IUserDailyPostCountService>();
            _postRepositoryMock = new Mock<IPostRepository>();
            _repostHistoryServiceMock = new Mock<IRepostHistoryService>();
            _mediatorMock = new Mock<IMediator>();
            _postFactoryMock = new Mock<IPostFactory>();

            _postService = new PostService(
                _userDailyPostLimitServiceMock.Object,
                _postRepositoryMock.Object,
                _repostHistoryServiceMock.Object,
                _mediatorMock.Object,
                _postFactoryMock.Object
            );
        }

        [Fact]
        public async Task AddPostAsync_Should_AddPost_WhenWithinDailyLimit()
        {
            int userId = 1;
            string content = "Test post";

            _userDailyPostLimitServiceMock
                .Setup(s => s.FindUserLimitByReferenceDateAsync(userId, It.IsAny<DateOnly>()))
                .ReturnsAsync(new UserDailyPostCount { PostCount = 0 });

            var mockPost = new Post { Id = 1, Content = content, AuthorUserId = userId };
            _postFactoryMock.Setup(f => f.CreatePost(content, userId)).Returns(mockPost);

            await _postService.AddPostAsync(content, userId);

            _postRepositoryMock.Verify(r => r.AddAsync(mockPost), Times.Once);
            _mediatorMock.Verify(m => m.Publish(It.IsAny<UpdateDailyPostCountEvent>(), default), Times.Once);
        }

        [Fact]
        public async Task AddRepostAsync_Should_AddRepost_WhenWithinDailyLimit_AndNotRepostedBefore()
        {
            int userId = 1;
            int originalPostId = 100;

            _userDailyPostLimitServiceMock
                .Setup(s => s.FindUserLimitByReferenceDateAsync(userId, It.IsAny<DateOnly>()))
                .ReturnsAsync(new UserDailyPostCount { PostCount = 0 });

            _repostHistoryServiceMock
                .Setup(s => s.FindRepostHistoryByUserAndPostAsync(userId, originalPostId))
                .ReturnsAsync((RepostHistory)null);

            var mockRepost = new Post { Id = 101, OriginalPostId = originalPostId, AuthorUserId = userId };
            _postFactoryMock.Setup(f => f.CreateRepost(originalPostId, userId)).Returns(mockRepost);

            await _postService.AddRepostAsync(originalPostId, userId);

            _postRepositoryMock.Verify(r => r.AddAsync(mockRepost), Times.Once);
            _mediatorMock.Verify(m => m.Publish(It.IsAny<UpdateRepostCountEvent>(), default), Times.Once);
        }

        [Fact]
        public async Task AddRepostAsync_ShouldThrowRepostNotAllowedException_WhenAlreadyReposted()
        {
            int userId = 1;
            int originalPostId = 100;

            _repostHistoryServiceMock
                .Setup(s => s.FindRepostHistoryByUserAndPostAsync(userId, originalPostId))
                .ReturnsAsync(new RepostHistory());

            await Assert.ThrowsAsync<RepostNotAllowedException>(() => _postService.AddRepostAsync(originalPostId, userId));
        }

        [Fact]
        public async Task AddPostAsync_ShouldThrowDailyPostLimitExceededException_WhenLimitExceeded()
        {
            int userId = 1;
            string content = "This is a test post";

            _userDailyPostLimitServiceMock
                .Setup(s => s.FindUserLimitByReferenceDateAsync(userId, It.IsAny<DateOnly>()))
                .ReturnsAsync(new UserDailyPostCount { PostCount = 5 });

            await Assert.ThrowsAsync<DailyPostLimitExceededException>(() => _postService.AddPostAsync(content, userId));
        }

    }
}

 




