using Diary_Server.Dtos.Users;
using Diary_Server.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Diary_Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterUserDto registerDto)
        {
            var user = _userService.Register(registerDto);
            if (user == null)
                return BadRequest("User could not be created.");

            return Ok(user);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginUserDto loginDto)
        {
            var token = _userService.Authenticate(loginDto, out var userDto);
            if (token == null)
                return Unauthorized("Invalid credentials.");

            var response = new
            {
                Token = token,
                User = userDto
            };

            return Ok(response);
        }
    }
}
