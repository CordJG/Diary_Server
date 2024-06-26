using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diary_Server.Models
{
    [Table("Diary")]
    public class Diary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public User User { get; set; }
        public long UserId { get; set; } // User identification

        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }

    }
}
