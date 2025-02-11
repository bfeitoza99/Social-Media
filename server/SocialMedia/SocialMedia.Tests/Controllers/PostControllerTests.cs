using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.API.Controllers;
using SocialMedia.Domain.Interfaces.Services;
using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Enums;
using SocialMedia.Application.DTO;

namespace SocialMedia.Tests.Controllers
{

    public class PostControllerTests
    {
        private readonly Mock<IPostService> _postServiceMock;
        private readonly PostController _controller;

        public PostControllerTests()
        {
            _postServiceMock = new Mock<IPostService>();
            _controller = new PostController();
        }

        [Fact]
        public async Task GetPosts_ShouldReturnPaginatedPosts_WhenValidParamsProvided()
        {
            var fakeResponse = new PaginatedResultViewModel<PostResponseViewModel>
            {
                Items = new List<PostResponseViewModel>
            {
                new PostResponseViewModel { Id = 1, Content = "Test Post", AuthorNickname = "User1" },
                new PostResponseViewModel { Id = 2, Content = "Another Test", AuthorNickname = "User2" }
            },
                TotalCount = 2,
                Page = 1,
                PageSize = 10
            };

            _postServiceMock.Setup(s => s
                .SetKeyword(It.IsAny<string>()))
                .Returns(_postServiceMock.Object);

            _postServiceMock.Setup(s => s
                .SetPageSize(It.IsAny<int>()))
                .Returns(_postServiceMock.Object);

            _postServiceMock.Setup(s => s
                .SetPage(It.IsAny<int>()))
                .Returns(_postServiceMock.Object);

            _postServiceMock.Setup(s => s
                .SetOrderBy(It.IsAny<PostOrderBy>()))
                .Returns(_postServiceMock.Object);

            _postServiceMock.Setup(s => s.FindPostsAsync())
                .ReturnsAsync(fakeResponse);

            var result = await _controller.GetPosts(_postServiceMock.Object);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<PaginatedResultViewModel<PostResponseViewModel>>(okResult.Value);
            Assert.Equal(2, response.Items.Count);
        }

        [Fact]
        public async Task Post_ShouldReturnOk_WhenPostIsValid()
        {
            var createPostDto = new CreatePostDTO { Content = "New Post", AuthorUserId = 1 };

            _postServiceMock.Setup(s => s.AddPostAsync(createPostDto.Content, createPostDto.AuthorUserId))
                .Returns(Task.CompletedTask);

            var result = await _controller.Post(_postServiceMock.Object, createPostDto);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            _controller.ModelState.AddModelError("Content", "Content is required");

            var createPostDto = new CreatePostDTO { Content = "", AuthorUserId = 1 };

            var result = await _controller.Post(_postServiceMock.Object, createPostDto);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task Repost_ShouldReturnOk_WhenRepostIsValid()
        {
            var createRepostDto = new CreateRepostDTO { AuthorUserId = 1 };
            int originalPostId = 100;

            _postServiceMock.Setup(s => s.AddRepostAsync(originalPostId, createRepostDto.AuthorUserId))
                .Returns(Task.CompletedTask);

            var result = await _controller.Repost(_postServiceMock.Object, originalPostId, createRepostDto);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Repost_ShouldReturnBadRequest_WhenModelStateIsInvalid()
        {
            _controller.ModelState.AddModelError("AuthorUserId", "AuthorUserId is required");

            var createRepostDto = new CreateRepostDTO { AuthorUserId = 0 };
            int originalPostId = 100;

            var result = await _controller.Repost(_postServiceMock.Object, originalPostId, createRepostDto);

            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(400, statusCodeResult.StatusCode);
        }
    }

}

