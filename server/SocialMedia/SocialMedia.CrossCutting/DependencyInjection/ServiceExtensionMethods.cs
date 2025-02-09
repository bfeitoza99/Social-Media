using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Services;
using SocialMedia.Domain.Interfaces.Repositories;
using SocialMedia.Domain.Interfaces.Services;
using SocialMedia.Infrastructure.Context.Repositories;


namespace SocialMedia.CrossCutting.DependencyInjection
{
    public static class ServiceExtensionMethods
    {

        public static IServiceCollection AddServices(this IServiceCollection services) =>

                services.AddScoped<IPostService, PostService>()
                .AddScoped<IUserDailyPostCountService, UserDailyPostLimitService>()
                .AddScoped<IRepostHistoryService, RepostHistoryService>();
    }
}
