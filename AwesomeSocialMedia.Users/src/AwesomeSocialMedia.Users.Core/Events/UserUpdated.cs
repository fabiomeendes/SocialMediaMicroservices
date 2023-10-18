using AwesomeSocialMedia.Users.Core.ValueObjects;

namespace AwesomeSocialMedia.Users.Core.Events
{
	public class UserUpdated : IEvent
	{
        public UserUpdated(string displayName, string header, string description, LocationInfo? location, ContactInfo? contact)
        {
            DisplayName = displayName;
            Header = header;
            Description = description;
            Location = location;
            Contact = contact;
        }
        
		public string DisplayName { get; private set; }
        public string Header { get; private set; }
        public string Description { get; private set; }
        public LocationInfo? Location { get; private set; }
        public ContactInfo? Contact { get; private set; }
    }
}

