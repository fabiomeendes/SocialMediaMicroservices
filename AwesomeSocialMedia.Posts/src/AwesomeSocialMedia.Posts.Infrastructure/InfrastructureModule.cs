using System;
using AwesomeSocialMedia.Posts.Core.Repositories;
using AwesomeSocialMedia.Posts.Infrastructure.EventBus;
using AwesomeSocialMedia.Posts.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AwesomeSocialMedia.Posts.Infrastructure
{
	public static class InfrastructureModule
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services
				.AddRepositories()
				.AddEventBus();

			return services;
		}

		private static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddSingleton<IPostRepository, PostRepository>();

			return services;
		}

		private static IServiceCollection AddEventBus(this IServiceCollection services)
		{
			services.AddScoped<IEventBus, RabbitMqService>();

			return services;
		}
	}
}

