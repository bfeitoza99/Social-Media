namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IPaginateService<T>
    {
        T SetOrderBy(string orderBy);
        T SetPageSize(int pageSize);
        T SetPage(int page);
    }
}
