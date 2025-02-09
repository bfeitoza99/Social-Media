
namespace SocialMedia.Domain.Interfaces.Repositories
{
    public interface IPaginateRepository<T>
    {
        T SetKeyword(string keyword);
        T SetOrderBy(string orderBy);
        T SetPageSize(int pageSize);
        T SetPage(int page);
    }
}
