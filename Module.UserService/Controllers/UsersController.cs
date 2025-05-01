using Microsoft.AspNetCore.Mvc;
using Module.UserService.Shared.Interfaces;

namespace Module.UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<string>>> GetActiveUsers()
        {
            var users = await _userService.GetActiveUsernamesAsync();
            return Ok(users);
        }
    }
}
