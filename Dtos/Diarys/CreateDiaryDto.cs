namespace Diary_Server.Dtos.Diarys
{
    public class CreateDiaryDto
    {
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
    }
}
