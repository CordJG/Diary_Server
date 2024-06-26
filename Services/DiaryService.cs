using Diary_Server.Contexts;
using Diary_Server.Dtos.Diarys;
using Diary_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Diary_Server.Services
{
    public interface IDiaryService
    {
        IEnumerable<DiaryDto> GetDiarys();
        IEnumerable<DiaryDto> GetUserDiarys(long userId);
        DiaryDto CreateEntry(CreateDiaryDto entry);
        void DeleteEntry(long userId);
    }

    public class DiaryService : IDiaryService
    {
        private readonly DiaryContext _context;

        public DiaryService(DiaryContext context)
        {
            _context = context;
        }

        public IEnumerable<DiaryDto> GetDiarys()
        {
            var diaries = _context.Diaries
                .Include(d => d.User)
                .ToList();

            return diaries.Select(e => new DiaryDto
            {
                Id = e.Id,
                Date = e.Date,
                Content = e.Content,
                IsPrivate = e.IsPrivate
            }).ToList();
        }


        public IEnumerable<DiaryDto> GetUserDiarys(long userId)
        {
            var diarys = _context.Diaries
                .Include(d => d.User)
                .Where(d => d.UserId == userId || !d.IsPrivate)
                .ToList();

            return diarys.Select(d => new DiaryDto
            {
                Id = d.Id,
                Date = d.Date,
                Content = d.Content,
                IsPrivate = d.IsPrivate
            }).ToList();
        }

        public DiaryDto CreateEntry(CreateDiaryDto entryDto)
        {
            var userId = entryDto.UserId;
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return null;

            var newEntry = new Diary
            {
                UserId = userId,
                User = user,
                Date = entryDto.Date,
                Content = entryDto.Content,
                IsPrivate = entryDto.IsPrivate
            };
            user.Diaries.Add(newEntry);

            _context.Diaries.Add(newEntry);
            _context.SaveChanges();

            return new DiaryDto
            {
                Id = newEntry.Id,
                Date = newEntry.Date,
                Content = newEntry.Content,
                IsPrivate = newEntry.IsPrivate
            };
        }

        public void DeleteEntry(long diaryId)
        {
            var entry = _context.Diaries.FirstOrDefault(e => e.Id == diaryId);
            if (entry != null)
            {
                _context.Diaries.Remove(entry);
                _context.SaveChanges();
            }
        }
    }
}
