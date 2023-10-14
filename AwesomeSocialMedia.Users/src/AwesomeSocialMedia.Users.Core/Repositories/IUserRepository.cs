using System;
using AwesomeSocialMedia.Users.Core.Entities;

namespace AwesomeSocialMedia.Users.Core.Repositories
{
	public interface IUserRepository
	{
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		Task<User?> GetByIdAsync(Guid id);
	}
}

