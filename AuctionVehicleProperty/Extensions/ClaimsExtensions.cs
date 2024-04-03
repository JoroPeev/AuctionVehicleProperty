using System.Security.Claims;

namespace AuctionVehicleProperty.Extensions
{
    public static class ClaimsExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
