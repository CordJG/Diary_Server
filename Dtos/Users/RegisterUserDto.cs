namespace Diary_Server.Dtos.Users
{
    public class RegisterUserDto
    {
        public string? Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
