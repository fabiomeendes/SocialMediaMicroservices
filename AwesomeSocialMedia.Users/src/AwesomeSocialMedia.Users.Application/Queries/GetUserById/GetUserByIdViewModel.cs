using AwesomeSocialMedia.Users.Core.Entities;

namespace AwesomeSocialMedia.Users.Application.Queries.GetUserById
{
    public class GetUserByIdViewModel
    {
        public GetUserByIdViewModel(User user)
        {
            DisplayName = user.DisplayName;
            BirthDate = user.BirthDate;
            Header = user.Header;
            Description = user.Description;
            Country = user.Location?.Country;
            Website = user.Contact?.Website;
        }

        public string DisplayName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string? Header { get; private set; }
        public string? Description { get; private set; }
        public string? Country { get; private set; }
        public string? Website { get; private set; }
    }
}