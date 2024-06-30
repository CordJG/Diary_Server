using Diary_Server.Models;

namespace Diary_Server.Interface
{
    public interface IDiaryContextHandler : IBaseContextHandler<Diary>
    {
        List<Diary> GetUserDiaries(long userId, long loginUserId);
    }
}
