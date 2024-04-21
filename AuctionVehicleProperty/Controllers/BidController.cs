using AuctionVehicleProperty.Core.Models.Bids;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class BidController : BaseController
    {
        [HttpPost]
        public IActionResult PlaceBid(PlacingBidAgent placingBid)
        {



            return Content("Bid placed successfully!");
        }
    }
}
