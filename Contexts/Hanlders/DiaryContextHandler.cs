using Diary_Server.Interface;
using Diary_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Diary_Server.Contexts.Hanlders
{
    public class DiaryContextHandler : BaseContextHandler<Diary> , IDiaryContextHandler
    {
        public DiaryContextHandler(DiaryContext context) : base(context)
        {
        }

        public List<Diary> GetUserDiaries(long userId, long loginUserId)
        {
            return _context.Set<Diary>()
                 .Include(d => d.User)
                 .Where(d => d.UserId == userId && (d.UserId == loginUserId || !d.IsPrivate))
                 .ToList();
        }
    }
}
