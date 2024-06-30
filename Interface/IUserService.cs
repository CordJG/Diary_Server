using Diary_Server.Dtos.Users;

namespace Diary_Server.Interface
{
    public interface IUserService
    {
        UserDto Register(RegisterUserDto registerDto);
        string Authenticate(LoginUserDto loginDto, out UserDto userDto);
        UserDto GetUserById(long id);
    }
}
