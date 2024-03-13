using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class BidController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
