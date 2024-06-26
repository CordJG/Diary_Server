namespace Diary_Server.Models
{
    public class User
    {
        public required string Id { get; set; } // User ID
        public string? Username { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Diary> Diaries { get; set; } = new List<Diary>();
    }
}
