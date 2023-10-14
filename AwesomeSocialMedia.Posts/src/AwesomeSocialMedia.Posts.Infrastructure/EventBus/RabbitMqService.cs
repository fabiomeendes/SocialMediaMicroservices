using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace AwesomeSocialMedia.Posts.Infrastructure.EventBus
{
	public class RabbitMqService : IEventBus
	{
        private readonly IModel _channel;
        private const string Exchange = "post";

		public RabbitMqService()
		{
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("posts.publisher");

            _channel = connection.CreateModel();

            _channel.ExchangeDeclare(Exchange, "direct", true, false);
		}

        public void Publish<T>(T @event)
        {
            // Por exemplo: PostCreated => post-created
            var routingKey = @event.GetType().Name.ToDashCase();

            var json = JsonConvert.SerializeObject(@event);
            var bytes = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(Exchange, routingKey, null, bytes);
        }
    }
}

