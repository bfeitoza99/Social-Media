namespace SocialMedia.Domain.Interfaces.Services
{
    public interface IPaginateService<T,O>
    {
        T SetOrderBy(O orderBy);
        T SetPageSize(int pageSize);
        T SetPage(int page);
    }
}
