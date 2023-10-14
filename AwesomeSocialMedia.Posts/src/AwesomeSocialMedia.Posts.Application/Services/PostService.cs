using System;
using AwesomeSocialMedia.Posts.Application.InputModels;
using AwesomeSocialMedia.Posts.Application.ViewModels;
using AwesomeSocialMedia.Posts.Core.Repositories;
using AwesomeSocialMedia.Posts.Infrastructure.EventBus;

namespace AwesomeSocialMedia.Posts.Application.Services
{
	public class PostService : IPostService
	{
		private readonly IPostRepository _repository;
		private readonly IEventBus _bus;
        public PostService(IPostRepository repository, IEventBus bus)
		{
			_repository = repository;
			_bus = bus;
        }

		public async Task<BaseResult<Guid>> Create(CreatePostInputModel model)
		{
			var post = model.ToEntity();

			await _repository.AddAsync(post);

			foreach (var @event in post.Events)
			{
				_bus.Publish(@event);
			}

			return new BaseResult<Guid>(post.Id);
		}

        public async Task<BaseResult> Delete(Guid id)
        {
			await _repository.DeleteAsync(id);

			return new BaseResult();
        }

        public async Task<BaseResult<List<PostItemViewModel>>> GetAll(Guid userId)
		{
			var posts = await _repository.GetAllAsync(userId);

			var viewModels = posts.Select(p => new PostItemViewModel(p)).ToList();

			return new BaseResult<List<PostItemViewModel>>(viewModels);
		}
	}
}

