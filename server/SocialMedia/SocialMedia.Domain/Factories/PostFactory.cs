using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Interfaces.Factories;

namespace SocialMedia.Infrastructure.Factories
{
    public class PostFactory : IPostFactory
    {
        public Post CreatePost(string content, int authorUserId)
        {
            return new Post
            {                
                AuthorUserId = authorUserId,
                Content = content

            };
        }

        public Post CreateRepost(int originalPostId, int authorUserId)
        {
            return new Post
            {              
                AuthorUserId = authorUserId,
                Content =  "",
                IsRepost = true,
                OriginalPostId = originalPostId
            };
        }
    }
}
