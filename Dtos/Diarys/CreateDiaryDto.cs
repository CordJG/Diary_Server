namespace Diary_Server.Dtos.Diarys
{
    public class CreateDiaryDto
    {
        public required long UserId { get; set; }
        public DateTime Date { get; set; }
        public string? Content { get; set; }
        public bool IsPrivate { get; set; }
    }
}
