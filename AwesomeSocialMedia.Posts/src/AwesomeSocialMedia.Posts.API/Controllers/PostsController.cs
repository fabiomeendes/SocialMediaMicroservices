using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeSocialMedia.Posts.Application.InputModels;
using AwesomeSocialMedia.Posts.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeSocialMedia.Posts.API.Controllers
{
    [Route("api/users/{userId}/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService _service;

        public PostsController(IPostService service)
        {
            _service = service;
        }

        // GET: api/users/f95a1f3d-5d40-4d4c-a7e0-cac5d356219b/posts
        [HttpGet]
        public async Task<IActionResult> Get(Guid userId)
        {
            var result = await _service.GetAll(userId);

            return Ok(result);
        }

        // POST api/user/f95a1f3d-5d40-4d4c-a7e0-cac5d356219b/posts
        [HttpPost]
        public async Task<IActionResult> Post(Guid userId, [FromBody] CreatePostInputModel model)
        {
            model.UserId = userId;

            var result = await _service.Create(model);

            return Ok(result);
        }

        // DELETE api/users/f95a1f3d-5d40-4d4c-a7e0-cac5d356219b/posts
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid userId, Guid id)
        {
            var result = await _service.Delete(id);

            return Ok(result);
        }
    }
}

