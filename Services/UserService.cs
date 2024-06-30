using AutoMapper;
using Diary_Server.Dtos.Users;
using Diary_Server.Interface;
using Diary_Server.Models;

namespace Diary_Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserContextHandler _userContextHandler;
        private readonly IMapper _mapper;
        private readonly IJwtHelper _jwtHelper;
        
        public UserService(IUserContextHandler userContextHandler, IMapper mapper, IJwtHelper jwtHelper)
        {
            _userContextHandler = userContextHandler;
            _mapper = mapper;
            _jwtHelper = jwtHelper;
        }

        public UserDto Register(RegisterUserDto registerDto)
        {
            var newUser = _mapper.Map<User>(registerDto);
            newUser.CreatedAt = DateTime.UtcNow;
            newUser.UpdatedAt = DateTime.UtcNow;

            _userContextHandler.Add(newUser);

            return _mapper.Map<UserDto>(newUser);
        }

        public string Authenticate(LoginUserDto loginDto, out UserDto userDto)
        {
            var user = _userContextHandler.GetAll()
                .FirstOrDefault(u => u.Email == loginDto.Email && u.Password == loginDto.Password); // Note: Store hashed passwords in production
            if (user == null)
            {
                userDto = null;
                return null;
            }

            var token = _jwtHelper.GenerateToken(user.Id, user.Email);
            userDto = _mapper.Map<UserDto>(user);
            return token;
        }

        public UserDto GetUserById(long id)
        {
            var user = _userContextHandler.GetById(id);
            if (user == null) return null;

            return _mapper.Map<UserDto>(user);
        }
    }
}
