using System;
using AwesomeSocialMedia.Users.Application.Models;
using AwesomeSocialMedia.Users.Core.Repositories;
using MediatR;

namespace AwesomeSocialMedia.Users.Application.Commands.UpdateUser
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResult>
	{
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
		{
            _repository = repository;
        }

        public async Task<BaseResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            user.Update(
                request.DisplayName,
                request.Header,
                request.Description,
                request.Location.ToValueObject(),
                request.Contact.ToValueObject());

            await _repository.UpdateAsync(user);

            return new BaseResult();
        }
    }
}

