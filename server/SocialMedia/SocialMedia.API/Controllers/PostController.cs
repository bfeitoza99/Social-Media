using Microsoft.AspNetCore.Mvc;
using SocialMedia.Domain.DTO;
using SocialMedia.Domain.Interfaces.Repositories;
using SocialMedia.Domain.Interfaces.Services;

namespace SocialMedia.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PostController : Controller
    {
        [HttpGet]
        [ProducesResponseType<PaginatedResult<PostResponseDTO>>(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPosts(
            [FromServices] IPostService postService,
            [FromQuery] int page = 1,
            [FromQuery] int pageSize = 15,
            [FromQuery] string? keyword = null,
            [FromQuery] string orderBy = "latest")
        {
            var result = await postService
                .SetKeyword(keyword)
                .SetPageSize(pageSize)
                .SetPage(page)
                .SetOrderBy(orderBy)
                .FindPostsAsync();

            return Ok(result);
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
            [FromBody] CreateRepostDTO model)
        {
            if (!ModelState.IsValid)
                return this.BadFormatModelStateResult();

            await postService.AddRepostAsync(originalPostId, model);

            return Ok();
        }

    }
}
