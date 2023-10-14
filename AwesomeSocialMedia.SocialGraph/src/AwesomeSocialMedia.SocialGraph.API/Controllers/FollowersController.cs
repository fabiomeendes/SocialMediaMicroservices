using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeSocialMedia.SocialGraph.Application.InputModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AwesomeSocialMedia.SocialGraph.API.Controllers
{
    [Route("api/user/{id}/followers")]
    public class FollowersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(Guid id, [FromBody] AddFollowerInputModel model)
        {
            return Ok();
        }

        [HttpDelete("{followeeId}")]
        public void Delete(int id)
        {
        }
    }
}

