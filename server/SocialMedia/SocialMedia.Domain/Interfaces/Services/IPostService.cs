using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Enums;
using SocialMedia.Domain.Interfaces.Repositories;

namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IPostService : IPaginateService<IPostService, PostOrderBy>
    {

        Task AddPostAsync(string content, int authorUserId);
        Task AddRepostAsync(int originalPostId,  int authorUserId);

        Task<PaginatedResultViewModel<PostResponseViewModel>> FindPostsAsync();

        IPostService SetKeyword(string keyword);

    }
}
