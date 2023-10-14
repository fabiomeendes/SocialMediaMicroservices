using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AwesomeSocialMedia.Newsfeed.API.Consumers
{
    public class UserUpdatedConsumer : BackgroundService
    {
        private readonly IModel _channel;
        private const string Queue = "newsfeed.user-updated";
        private const string Exchange = "user";
        private const string RoutingKey = "user-updated";

        public UserUpdatedConsumer()
        {
            // Configurando conexão com RabbitMQ
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("newsfeed.user-updated");

            _channel = connection.CreateModel();

            // Garantir que Exchange e Fila estão criados, e fazer o Binding entre eles
            _channel.QueueDeclare(Queue, true, false, false, null);

            _channel.ExchangeDeclare(Exchange, "direct", true, false);

            _channel.QueueBind(Queue, Exchange, RoutingKey);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var json = Encoding.UTF8.GetString(contentArray);

                // Converter o evento utilizando JsonConvert.Deserializeobject<T>

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }
    }
}

