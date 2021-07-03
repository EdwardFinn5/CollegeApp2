using System.Security.Claims;

namespace API.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static string GetColUserName(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static int GetColUserId(this ClaimsPrincipal colUser)
        {
            return int.Parse(colUser.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
    }
}