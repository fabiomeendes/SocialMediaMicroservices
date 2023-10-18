using System;
using AwesomeSocialMedia.Users.Application.Models;
using AwesomeSocialMedia.Users.Core.Repositories;
using AwesomeSocialMedia.Users.Infrastructure.EventBus;
using MediatR;

namespace AwesomeSocialMedia.Users.Application.Commands.UpdateUser
{
	public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseResult>
	{
        private readonly IUserRepository _repository;
        private readonly IEventBus _bus;

        public UpdateUserCommandHandler(IUserRepository repository, IEventBus bus)
		{
            _repository = repository;
            _bus = bus;
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

            foreach (var @event in user.Events)
            {
                _bus.Publish(@event);
            }

            return new BaseResult();
        }
    }
}

