using Diary_Server.Contexts;
using Diary_Server.Dtos.Users;
using Diary_Server.Models;

namespace Diary_Server.Services
{
    public interface IUserService
    {
        UserDto Register(RegisterUserDto registerDto);
        UserDto Authenticate(LoginUserDto loginDto);
        UserDto GetUserById(long id);
    }

    public class UserService : IUserService
    {

        private readonly DiaryContext _context;

        public UserService(DiaryContext context)
        {
            _context = context;
        }

        public UserDto Register(RegisterUserDto registerDto)
        {
            var newUser = new User
            {
                Id = registerDto.Id,
                Username = registerDto.Username,
                Password = registerDto.Password, // Note: Store hashed passwords in production
                Email = registerDto.Email,
                CreatedAt = DateTime.UtcNow
            };
            
            _context.Users.Add(newUser);
            _context.SaveChanges();

            return new UserDto
            {
                Id = newUser.Id,
                Username = newUser.Username,
                Email = newUser.Email,
                CreatedAt = newUser.CreatedAt
            };
        }

        public UserDto Authenticate(LoginUserDto loginDto)
        {
            var user = _context.Users
                 .FirstOrDefault(u => u.Username == loginDto.Username && u.Password == loginDto.Password);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        public UserDto GetUserById(long id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }
    }
}
