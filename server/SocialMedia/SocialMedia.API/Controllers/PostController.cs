using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Domain.DTO;
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
        public async Task<IActionResult> Post(
            [FromServices] IPostService postService, 
            [FromBody] CreatePostDTO model)
        {
            await postService.AddPostAsync(model);
            return Ok();
        }

        [HttpPost("repost")]
        public async Task<IActionResult> Repost(
            [FromServices] IPostService postService,
            [FromBody] RepostDTO model)
        {
            await postService.AddRepostAsync(model);
            return Ok();
        }

    }
}
