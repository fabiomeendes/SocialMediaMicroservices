using System;
using AwesomeSocialMedia.Posts.Core.Entities;
using AwesomeSocialMedia.Posts.Core.Repositories;

namespace AwesomeSocialMedia.Posts.Infrastructure.Persistence.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly List<Post> _posts;
        public PostRepository()
        {
            _posts = new List<Post>();
        }
        
        public Task AddAsync(Post post)
        {
            _posts.Add(post);

            return Task.CompletedTask;
        }

        public Task DeleteAsync(Guid id)
        {
            var post = _posts.SingleOrDefault(p => p.Id == id);

            if (post is null)
            {
                throw new InvalidOperationException();
            }

            post.Delete();

            return Task.CompletedTask;
        }

        public Task<List<Post>> GetAllAsync(Guid userId)
        {
            var userPosts = _posts.Where(p => p.User.Id == userId && !p.IsDeleted).ToList();
            
            return Task.FromResult(userPosts);
        }
    }
}

