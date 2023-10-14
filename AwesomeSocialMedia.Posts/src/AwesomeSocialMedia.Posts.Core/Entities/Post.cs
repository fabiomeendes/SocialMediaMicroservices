using System;
using AwesomeSocialMedia.Posts.Core.Events;

namespace AwesomeSocialMedia.Posts.Core.Entities
{
	public class Post : AggregateRoot
	{
		public Post(string content, User user) : base()
		{
			Content = content;
			User = user;

			AddEvent(new PostCreated(Id, Content, CreatedAt, User));
		}

		public string Content { get; private set; }
		public User User { get; set; }
	}
}

