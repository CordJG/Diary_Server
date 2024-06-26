using Diary_Server.Dtos.Users;
using Diary_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace Diary_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public ActionResult<UserDto> Register([FromBody] RegisterUserDto registerDto)
        {
            var user = _userService.Register(registerDto);
            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<UserDto> Login([FromBody] LoginUserDto loginDto)
        {
            var user = _userService.Authenticate(loginDto);
            if (user == null)
                return Unauthorized();
            return Ok(user);
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
