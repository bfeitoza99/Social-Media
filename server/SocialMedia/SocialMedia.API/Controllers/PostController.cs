using Microsoft.AspNetCore.Mvc;
using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Interfaces.Services;

namespace SocialMedia.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
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
            [FromBody] CreatePostDTO model
            )
        {
            if (!ModelState.IsValid)
                return this.BadFormatModelStateResult();            

            await postService.AddPostAsync(model);

            return Ok();
        }

        [HttpPost("{originalPostId}/repost")]
        public async Task<IActionResult> Repost(
            [FromServices] IPostService postService,
            [FromRoute] int originalPostId,
            [FromBody] RepostDTO model)
        {
            if (!ModelState.IsValid)
                return this.BadFormatModelStateResult();

            await postService.AddRepostAsync(originalPostId, model);

            return Ok();
        }

    }
}
