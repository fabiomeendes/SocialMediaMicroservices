using System;
using System.Text;
using AwesomeSocialMedia.Newsfeed.API.Core.Entities;
using AwesomeSocialMedia.Newsfeed.API.Core.Repositories;
using Microsoft.AspNetCore.Connections;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AwesomeSocialMedia.Newsfeed.API.Consumers
{
    public class PostCreatedConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IModel _channel;
        private const string Queue = "newsfeed.post-created";
        private const string Exchange = "post";
        private const string RoutingKey = "post-created";

        public PostCreatedConsumer(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection("newsfeed.post-created");

            _channel = connection.CreateModel();

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
                var @event = JsonConvert.DeserializeObject<PostCreated>(json);

                Console.WriteLine(json);

                await AddToNewsfeed(@event);

                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };

            _channel.BasicConsume(Queue, false, consumer);

            return Task.CompletedTask;
        }

        private async Task AddToNewsfeed(PostCreated @event) {
            using (var scope = _serviceProvider.CreateScope())
            {
                var repository = scope.ServiceProvider.GetRequiredService<IUserNewsfeedRepository>();

                var post = new Post(@event.Id, @event.Content, @event.PublishedAt);
                var user = @event.User;

                await repository.AddPost(user, post);
            }
        }
    }

    public class PostCreated
	{
        public Guid Id { get; set; }
        public string Content { get; set; }
		public DateTime PublishedAt { get; set; }
		public User User { get; set; }
	}
}

