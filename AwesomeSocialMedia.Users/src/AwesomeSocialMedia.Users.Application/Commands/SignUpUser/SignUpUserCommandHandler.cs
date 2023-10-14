using System;
using AwesomeSocialMedia.Users.Application.Models;
using AwesomeSocialMedia.Users.Core.Entities;
using AwesomeSocialMedia.Users.Core.Repositories;
using MediatR;

namespace AwesomeSocialMedia.Users.Application.Commands.SignUpUser
{
	public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, BaseResult<Guid>>
	{
        private readonly IUserRepository _repository;

        public SignUpUserCommandHandler(IUserRepository repository)
		{
            _repository = repository;
        }

        public async Task<BaseResult<Guid>> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            var user = request.ToEntity();

            await _repository.AddAsync(user);

            /*try
            {
                _bus.Publish(user);
            } catch (Exception)
            {
                _outboxRepository.Add(user.Events.First());
            }*/

            return new BaseResult<Guid>(user.Id);
        }
    }
}

