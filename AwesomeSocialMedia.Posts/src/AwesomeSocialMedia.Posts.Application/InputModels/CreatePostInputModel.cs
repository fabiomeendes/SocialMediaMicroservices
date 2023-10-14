using System;
using AwesomeSocialMedia.Posts.Core.Entities;

namespace AwesomeSocialMedia.Posts.Application.InputModels
{
	public class CreatePostInputModel
    {
		public string Content { get; set; }
		public string UserDisplayName { get; set; }
		public Guid UserId { get; set; }

		public Post ToEntity()
			=> new Post(Content, new User(UserId, UserDisplayName));
	}
}

