using Microsoft.AspNetCore.Mvc;
using SocialMedia.Domain.Interfaces.Repositories;

namespace SocialMedia.API.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index([FromServices] IUserRepository userRepository)
        {
            return Ok(await userRepository.FindAllAsync());
        }
    }
}
