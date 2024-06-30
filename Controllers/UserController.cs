using Diary_Server.Dtos.Users;
using Diary_Server.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diary_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("{userId}")]
        public ActionResult<UserDto> GetUserById(long userId)
        {
            var user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
