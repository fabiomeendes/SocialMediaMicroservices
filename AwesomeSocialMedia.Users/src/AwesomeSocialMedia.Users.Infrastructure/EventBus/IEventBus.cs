namespace AwesomeSocialMedia.Users.Infrastructure.EventBus
{
    public interface IEventBus
    {
        void Publish<T>(T @event);
    }
}