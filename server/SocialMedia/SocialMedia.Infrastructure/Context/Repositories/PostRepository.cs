using Microsoft.EntityFrameworkCore;
using SocialMedia.Domain.DTO;
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

        private string _keyword;
        private string _orderBy;
        private int  _page;
        private int _pageSize;


        public async Task<PaginatedResult<PostResponseDTO>> GetPostsAsync()
        {
            var posts = _context.Posts
                .Include(p => p.User)
                .Include(p => p.OriginalPost) 
                .ThenInclude(op => op.User)   
                .AsQueryable();


            var teste = posts.ToList();
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



        public async Task IncrementRepostCountAsync(int postId)
        {
            var post = await _context.Posts.FindAsync(postId);

            if (post != null)
            {
                post.IncrementRepost();
                await _context.SaveChangesAsync();
            }
        }

        public IPostRepository SetKeyword(string keyword)
        {
            _keyword = keyword;
            return this;
        }

        public IPostRepository SetOrderBy(string orderBy)
        {
            _orderBy = orderBy;
            return this;
        }

        public IPostRepository SetPage(int page)
        {
            _page = page;
            return this;
        }

        public IPostRepository SetPageSize(int pageSize)
        {
            _pageSize = pageSize;
            return this;
        }
    }
}
