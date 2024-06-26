namespace Diary_Server.Dtos.Diarys
{
    public class DiaryDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
    }
}
