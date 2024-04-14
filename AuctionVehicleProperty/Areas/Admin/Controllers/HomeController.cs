using AuctionVehicleProperty.Areas.Admin.Controllers.HouseRentingSystem.Areas.Admin.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DashBoard()
        {
            return View();
        }

        public IActionResult ForReview()
        {
            return View();
        }
    }
}
