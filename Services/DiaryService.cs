using Diary_Server.Contexts;
using Diary_Server.Dtos.Diarys;
using Diary_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Diary_Server.Services
{
    public interface IDiaryService
    {
        IEnumerable<DiaryDto> GetEntries(string userId);
        DiaryDto GetEntry(int id, string userId);
        DiaryDto CreateEntry(string userId, CreateDiaryDto entry);
        void DeleteEntry(int id, string userId);
    }

    public class DiaryService : IDiaryService
    {
        private readonly DiaryContext _context;

        public DiaryService(DiaryContext context)
        {
            _context = context;
        }

        public IEnumerable<DiaryDto> GetEntries(string userId)
        {
            var user = _context.Users.Include(u => u.Diaries).FirstOrDefault(u => u.Id == userId);
            if (user == null) return Enumerable.Empty<DiaryDto>();

            return user.Diaries.Select(e => new DiaryDto
            {
                Id = e.Id,
                Date = e.Date,
                Content = e.Content,
                IsPrivate = e.IsPrivate
            }).ToList();
        }

        public DiaryDto GetEntry(int id, string userId)
        {
            var entry = _context.Diaries.Include(d => d.User)
                .FirstOrDefault(e => e.Id == id && (e.UserId == userId || !e.IsPrivate));

            if (entry == null) return null;

            return new DiaryDto
            {
                Id = entry.Id,
                Date = entry.Date,
                Content = entry.Content,
                IsPrivate = entry.IsPrivate
            };
        }

        public DiaryDto CreateEntry(string userId, CreateDiaryDto entryDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return null;

            var newEntry = new Diary
            {
                Id = user.Diaries.Count + 1,
                UserId = userId,
                User = user,
                Date = entryDto.Date,
                Content = entryDto.Content,
                IsPrivate = entryDto.IsPrivate
            };
            user.Diaries.Add(newEntry);

            return new DiaryDto
            {
                Id = newEntry.Id,
                Date = newEntry.Date,
                Content = newEntry.Content,
                IsPrivate = newEntry.IsPrivate
            };
        }

        public void DeleteEntry(int id, string userId)
        {
            var entry = _context.Diaries.FirstOrDefault(e => e.Id == id && e.UserId == userId);
            if (entry != null)
            {
                _context.Diaries.Remove(entry);
                _context.SaveChanges();
            }
        }
    }
}
