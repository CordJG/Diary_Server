using System.ComponentModel.DataAnnotations.Schema;

namespace Diary_Server.Models
{
    [Table("Diary")]
    public class Diary
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; } // User identification

        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }

    }
}
