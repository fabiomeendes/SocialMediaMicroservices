using System;
using AwesomeSocialMedia.Users.Application.Models;
using MediatR;

namespace AwesomeSocialMedia.Users.Application.Commands.UpdateUser
{
	public class UpdateUserCommand : IRequest<BaseResult>
	{
		public Guid Id { get; set; }
		public string DisplayName { get; set; }
		public string Header { get; set; }
		public string Description { get; set; }
		public LocationInfoModel Location { get; set; }
		public ContactInfoModel Contact { get; set; }
	}
}

