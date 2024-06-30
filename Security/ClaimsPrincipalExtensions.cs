using System.Security.Claims;

namespace Diary_Server.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static long GetUserId(this ClaimsPrincipal user)
        {
            return long.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }
}
