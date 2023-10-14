using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeSocialMedia.Newsfeed.API.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeSocialMedia.Newsfeed.API.Controllers
{
    [Route("api/newsfeed")]
    public class NewsfeedsController : Controller
    {
        private readonly IUserNewsfeedRepository _repository;

        public NewsfeedsController(IUserNewsfeedRepository repository)
        {
            _repository = repository;
        }

        // Não é para pegar a timeline, e sim o feed de posts de um usuário
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserNewsfeed(Guid userId)
        {
            var newsfeed = await _repository.GetByUserId(userId);

            if (newsfeed is null)
            {
                return NotFound();
            }

            return Ok(newsfeed);
        }
    }
}

