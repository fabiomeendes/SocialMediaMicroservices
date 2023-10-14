using System;
using AwesomeSocialMedia.Posts.Core.Entities;

namespace AwesomeSocialMedia.Posts.Application.ViewModels
{
	public class PostItemViewModel
	{
        public PostItemViewModel(Post post)
        {
            Content = post.Content;
            UserDisplayName = post.User.DisplayName;
            UserId = post.User.Id;
            Id = post.Id;
        }

        public Guid Id { get; set; }
        public string Content { get; private set; }
        public string UserDisplayName { get; private set; }
        public Guid UserId { get; private set; }
    }
}

