using System;
using AwesomeSocialMedia.Users.Application.Models;
using AwesomeSocialMedia.Users.Core.Entities;
using MediatR;

namespace AwesomeSocialMedia.Users.Application.Commands.SignUpUser
{
	public class SignUpUserCommand : IRequest<BaseResult<Guid>>
	{
		public string FullName { get; set; }
		public string DisplayName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Email { get; set; }

		public User ToEntity() => new User(FullName, DisplayName, BirthDate, Email);
	}
}

