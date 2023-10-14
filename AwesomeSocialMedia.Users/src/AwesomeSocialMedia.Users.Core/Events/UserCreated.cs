using System;
namespace AwesomeSocialMedia.Users.Core.Events
{
	public class UserCreated : IEvent
	{
        public UserCreated(string email, string displayName)
        {
            Email = email;
            DisplayName = displayName;
        }

        public string Email { get; private set; }
		public string DisplayName { get; private set; }
	}
}

