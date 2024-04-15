using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static AuctionVehicleProperty.Core.Constants.RoleConstants;

namespace AuctionVehicleProperty.Areas.Admin.Controllers
{

    namespace AuctionVehicleProperty.Areas.Admin.Controllers
    {
        [Area("Admin")]
        [Authorize(Roles = AdminRole)]
        public class AdminBaseController : Controller
        {

        }
    }
}
