﻿namespace Diary_Server.Dtos.Diarys
{
    public class DiaryDto
    {
        public long Id { get; set; }
        public DateTime DiaryDate { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public bool IsPrivate { get; set; }
    }
}
