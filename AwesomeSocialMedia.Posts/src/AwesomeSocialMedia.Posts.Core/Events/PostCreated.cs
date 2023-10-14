using System;
using AwesomeSocialMedia.Posts.Core.Entities;

namespace AwesomeSocialMedia.Posts.Core.Events
{
	public class PostCreated : IEvent
	{
		public PostCreated(Guid id, string content, DateTime? createdAt, User user)
        {
            Id = id;
            Content = content;
            PublishedAt = createdAt;
            User = user;
        }

        public Guid Id { get; private set; }
		public string Content { get; private set; }
		public DateTime? PublishedAt { get; private set; }
        public User User { get; set; }
    }
}

