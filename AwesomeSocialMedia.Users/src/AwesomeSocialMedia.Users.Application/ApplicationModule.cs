using AwesomeSocialMedia.Users.Application.Queries.GetUserById;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeSocialMedia.Users.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services
                .AddMediator();

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(typeof(ApplicationModule));

            return services;
        }
    }
}
