using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
