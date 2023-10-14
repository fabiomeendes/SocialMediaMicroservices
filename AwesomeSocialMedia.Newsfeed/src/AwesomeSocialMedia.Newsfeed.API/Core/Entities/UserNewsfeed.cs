using System;
namespace AwesomeSocialMedia.Newsfeed.API.Core.Entities
{
	public class UserNewsfeed
	{
        public UserNewsfeed(List<Post> posts, User user)
        {
            Id = Guid.NewGuid();
            Posts = posts;
            User = user;
        }

        public Guid Id { get; set; }
        public List<Post> Posts { get; private set; }
		public User User { get; private set; }

        public void AddPost(Post post)
        {
            Posts.Add(post);
        }
	}
}

