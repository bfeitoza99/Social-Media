using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Domain.Interfaces.Repositories;
using SocialMedia.Infrastructure.Context.Repositories;


namespace SocialMedia.CrossCutting.DependencyInjection
{
    public static class RepositoryExtensionMethods
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        
                services.AddScoped<IPostRepository, PostRepository>()
                .AddScoped<IRepostHistoryRepository, RepostHistoryRepository>()
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserDailyPostCountRepository, UserDailyPostCountRepository>();        
    }
}
