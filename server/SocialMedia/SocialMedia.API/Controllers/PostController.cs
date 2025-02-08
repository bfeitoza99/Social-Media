using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Domain.Interfaces.Services;

namespace SocialMedia.API.Controllers
{
    [Produces("application/json")]
    [Route("api/posts")]
    public class PostController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromServices] IPostService postService)
        {
            await postService.AddPostAsync();
            return Ok();
        }

        [HttpPost("repost")]
        public async Task<IActionResult> PostRepost([FromServices] IPostService postService)
        {
            await postService.AddRepostAsync();
            return Ok();
        }

    }
}
