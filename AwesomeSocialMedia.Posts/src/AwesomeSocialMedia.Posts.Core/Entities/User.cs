using System;
namespace AwesomeSocialMedia.Posts.Core.Entities
{
	public class User
	{
        public User(Guid id, string displayName)
        {
            Id = id;
            DisplayName = displayName;
        }

        public Guid Id { get; private set; }
		public string DisplayName { get; private set; }
	}
}

