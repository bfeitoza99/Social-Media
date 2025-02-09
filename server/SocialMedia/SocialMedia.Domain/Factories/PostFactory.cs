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
                AuthorUserId = model.AuthorUserId,
                Content = model.Content           
            
            };
        }

        public Post CreateRepost(int originalPostId, CreateRepostDTO model)
        {
            return new Post
            {              
                AuthorUserId = model.AuthorUserId,
                Content =  "",
                IsRepost = true,
                OriginalPostId = originalPostId
            };
        }
    }
}
