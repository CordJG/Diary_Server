namespace Diary_Server.Interface
{
    public interface IJwtHelper
    {
        string GenerateToken(long userId, string email);
    }

}
