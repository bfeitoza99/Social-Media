using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Application.Services;
using SocialMedia.Domain.Interfaces.Factories;
using SocialMedia.Domain.Interfaces.Services;
using SocialMedia.Infrastructure.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.CrossCutting.DependencyInjection
{
    public static class FactoryExtensionMethods
    {
        public static IServiceCollection AddFactories(this IServiceCollection services) =>

                services.AddScoped<IPostFactory, PostFactory>();
    }
}
