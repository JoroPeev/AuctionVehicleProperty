using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class BidController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
