using System;
using AwesomeSocialMedia.Users.Application.Models;
using AwesomeSocialMedia.Users.Core.Repositories;
using MediatR;

namespace AwesomeSocialMedia.Users.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, BaseResult<GetUserByIdViewModel>>
    {
        private readonly IUserRepository _repository;
        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResult<GetUserByIdViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(request.Id);

            var viewModel = new GetUserByIdViewModel(user);

            return new BaseResult<GetUserByIdViewModel>(viewModel);
        }
    }
}

