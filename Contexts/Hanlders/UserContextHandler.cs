using Diary_Server.Interface;
using Diary_Server.Models;

namespace Diary_Server.Contexts.Hanlders
{
    public class UserContextHandler : BaseContextHandler<User>, IUserContextHandler
    {
        public UserContextHandler(DiaryContext context) : base(context)
        {
        }

        
    }
}
