using Xunit;
using FluentAssertions;
using SocialMedia.Infrastructure.Factories;
using SocialMedia.Domain.Entities;

namespace SocialMedia.Tests.Factories
{  

    public class PostFactoryTests
    {
        private readonly PostFactory _postFactory;

        public PostFactoryTests()
        {
            _postFactory = new PostFactory();
        }

        [Fact]
        public void CreatePost_ShouldReturnNewPost_WithGivenContentAndAuthor()
        {
            var content = "Test post content";
            var authorUserId = 1;

            var result = _postFactory.CreatePost(content, authorUserId);

            result.Should().NotBeNull();
            result.Content.Should().Be(content);
            result.AuthorUserId.Should().Be(authorUserId);
            result.IsRepost.Should().BeFalse();
            result.OriginalPostId.Should().BeNull();
        }

        [Fact]
        public void CreateRepost_ShouldReturnNewRepost_WithGivenOriginalPostIdAndAuthor()
        {
            var originalPostId = 100;
            var authorUserId = 1;

            var result = _postFactory.CreateRepost(originalPostId, authorUserId);

            result.Should().NotBeNull();
            result.Content.Should().BeEmpty();
            result.AuthorUserId.Should().Be(authorUserId);
            result.IsRepost.Should().BeTrue();
            result.OriginalPostId.Should().Be(originalPostId);
        }
    }

}
