namespace Diary_Server.Dtos.Diarys
{
    public class CreateDiaryDto
    {
        public long UserId { get; set; }
        public string? Title { get; set; } 
        public string? Content { get; set; }
        public bool IsPrivate { get; set; }
        public DateTime DiaryDate { get; set; }
        
    }
}
