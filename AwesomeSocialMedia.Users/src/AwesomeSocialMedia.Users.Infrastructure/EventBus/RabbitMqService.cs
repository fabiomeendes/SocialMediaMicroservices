using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace AwesomeSocialMedia.Users.Infrastructure.EventBus
{
    public class RabbitMqService : IEventBus
    {
        private readonly IModel _channel;
        private const string Exchange = "user";
        public RabbitMqService()
        {
            var conncetionFactory = new ConnectionFactory
            {
                HostName = "localhost",
            };

            var connection = conncetionFactory.CreateConnection("users.publisher");

            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(Exchange, "direct", true, false);
        }
        public void Publish<T>(T @event)
        {
            var routingKey = @event.GetType().Name.ToDashCase();

            var json = JsonConvert.SerializeObject(@event);
            var bytes = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(Exchange, routingKey, null, bytes);
        }
    }
}
