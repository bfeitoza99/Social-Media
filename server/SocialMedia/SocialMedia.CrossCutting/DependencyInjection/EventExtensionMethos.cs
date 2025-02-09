using Microsoft.Extensions.DependencyInjection;
using SocialMedia.Domain.Interfaces.Repositories;
using SocialMedia.Infrastructure.Context.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.CrossCutting.DependencyInjection
{
    public static class EventExtensionMethos
    {
        public static IServiceCollection AddEvents(this IServiceCollection services) =>

              services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}


