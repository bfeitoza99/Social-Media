using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Interfaces.Repositories;

namespace SocialMedia.Infrastructure.Context.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        private readonly AppDbContext _context;
        public PostRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }



        public async Task IncrementRepostCountAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post != null)
            {
                post.IncrementRepost();
                await _context.SaveChangesAsync();
            }
        }


    }
}
