using System;
using AwesomeSocialMedia.Posts.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeSocialMedia.Posts.Application
{
	public static class ApplicationModule
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services
				.AddServices();

			return services;
		}

		private static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddScoped<IPostService, PostService>();

			return services;
		}
	}
}

