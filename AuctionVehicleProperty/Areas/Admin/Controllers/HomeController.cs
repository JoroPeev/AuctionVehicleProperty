using AuctionVehicleProperty.Areas.Admin.Controllers.AuctionVehicleProperty.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult DashBoard()
        {
            return View();
        }
    }
}
