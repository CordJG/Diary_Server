namespace Diary_Server.Dtos.Users
{
    public class RegisterUserDto
    {
        public long Id { get; set; }
        public string? Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
    }
}
