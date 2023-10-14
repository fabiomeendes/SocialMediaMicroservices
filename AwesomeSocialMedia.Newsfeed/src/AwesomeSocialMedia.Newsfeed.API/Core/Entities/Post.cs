using System;
namespace AwesomeSocialMedia.Newsfeed.API.Core.Entities
{
	public class Post
	{
        public Post(Guid id, string content, DateTime publishedAt)
        {
            Id = id;
            Content = content;
            PublishedAt = publishedAt;
        }

        public Guid Id { get; private set; }
        public string Content { get; private set; }
        public DateTime PublishedAt { get; private set; }

    }
}

