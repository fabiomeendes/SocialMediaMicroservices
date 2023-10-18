using System;
using AwesomeSocialMedia.Users.Core.Enums;
using AwesomeSocialMedia.Users.Core.Events;
using AwesomeSocialMedia.Users.Core.ValueObjects;

namespace AwesomeSocialMedia.Users.Core.Entities
{
    public class User : AggregateRoot
    {
        public User(string fullName, string displayName, DateTime birthDate, string email) : base()
        {
            FullName = fullName;
            DisplayName = displayName;
            BirthDate = birthDate;
            Email = email;

            Status = UserStatus.Active;

            Events.Add(new UserCreated(Email, DisplayName));
        }

        public string FullName { get; private set; }
        public string DisplayName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? Header { get; private set; }
        public string? Description { get; private set; }
        public string Email { get; private set; }
        public UserStatus Status { get; private set; }
        public LocationInfo? Location { get; private set; }
        public ContactInfo? Contact { get; private set; }

        public void Update
        (
            string displayName,
            string header,
            string description,
            LocationInfo location,
            ContactInfo contact
        )
        {
            DisplayName = displayName;
            Header = header;
            Description = description;
            Location = location;
            Contact = contact;

            Events.Add(new UserUpdated(DisplayName, Header, Description, Location, Contact));
        }
    }
}

