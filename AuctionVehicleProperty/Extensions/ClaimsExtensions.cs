using System.Security.Claims;
using static AuctionVehicleProperty.Core.Constants.RoleConstants;

namespace AuctionVehicleProperty.Extensions
{
    public static class ClaimsExtensions
    {
        public static string Id(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public static bool IsAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRole);
        }
    }
}
