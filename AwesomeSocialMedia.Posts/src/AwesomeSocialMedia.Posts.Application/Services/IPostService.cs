using System;
using AwesomeSocialMedia.Posts.Application.InputModels;
using AwesomeSocialMedia.Posts.Application.ViewModels;

namespace AwesomeSocialMedia.Posts.Application.Services
{
	public interface IPostService
	{
		Task<BaseResult<Guid>> Create(CreatePostInputModel model);
		Task<BaseResult<List<PostItemViewModel>>> GetAll(Guid userId);
		Task<BaseResult> Delete(Guid id);
	}
}

