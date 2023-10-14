using System;
namespace AwesomeSocialMedia.Posts.Infrastructure.EventBus
{
	public interface IEventBus
	{
		void Publish<T>(T @event);
	}
}

