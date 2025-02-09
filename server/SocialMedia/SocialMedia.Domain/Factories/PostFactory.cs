using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Interfaces.Factories;

namespace SocialMedia.Infrastructure.Factories
{
    public class PostFactory : IPostFactory
    {
        public Post CreatePost(CreatePostDTO model)
        {
            return new Post
            {
                AuthorNickname = model.AuthorNickname,
                AuthorUserId = model.AuthorUserId,
                Content = model.Content,             
            };
        }

        public Post CreateRepost(RepostDTO model)
        {
            return new Post
            {
                AuthorNickname = model.AuthorNickname,
                AuthorUserId = model.AuthorUserId,
                IsRepost = true,
                OriginalPostId = model.OriginalPostId
            };
        }
    }
}
