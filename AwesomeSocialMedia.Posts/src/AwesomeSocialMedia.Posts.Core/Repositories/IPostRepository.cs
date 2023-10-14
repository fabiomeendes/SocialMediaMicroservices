using System;
using AwesomeSocialMedia.Posts.Core.Entities;

namespace AwesomeSocialMedia.Posts.Core.Repositories
{
	public interface IPostRepository
	{
		Task AddAsync(Post post);
		Task<List<Post>> GetAllAsync(Guid userId);
		Task DeleteAsync(Guid id);
	}
}

