using System.Security.Claims;

namespace API.Extensions
{
    public static class CalimPrinicipalExtensions
    {
        public static string RetriveEmailFromPrincipal(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.Email);
        }
    }
}