using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Auctions;
using AuctionVehicleProperty.Core.Models.Bids;
using AuctionVehicleProperty.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class BidController : BaseController
    {
        private readonly IBidService bidService;
        private readonly IAgentService agentService; 
        private readonly IAuctionService auctionService;
        public BidController(IBidService _bidService, IAgentService _agentService, IAuctionService _auctionService)
        {
            agentService = _agentService;
            bidService = _bidService;
            auctionService = _auctionService;
        }
        [MustBeSeller]
        public async Task<IActionResult> Joined(int auctionId)
        {
            var ac = await auctionService.AuctionExistAsync(auctionId);
            if (ac == false) { return BadRequest(); }
            var details = await auctionService.GetAuctionDetailsAsync(auctionId);
            
            var maxBid = await bidService.GetHighestBidAsync(auctionId);

            if (maxBid == -1.1m)
            {
                maxBid = details.StartingPrice;
            }
            details.MaxCurrentPrice = maxBid;
            if (maxBid == -1.1m)
            {
                return BadRequest();
            }

            return View(details);
        }

        [HttpPost]
        [MustBeSeller]
        public async Task<IActionResult> PlaceBid(int auctionId, decimal amount)
        {
            var agent = await agentService.GetAgentIdAsync(User.Id());

            if (agent == -1)
            {
                return Unauthorized();

            }
            if (auctionId==0)
            {
                return BadRequest();
            }

            var maxBid = await bidService.GetHighestBidAsync(auctionId);

            if (maxBid==1.1m)
            {
                return BadRequest();
            }

            if (amount<maxBid)
            {
                ModelState.AddModelError("Amount", "Bid amount must be higher than the current highest bid.");
                return View();
            }

            await bidService.PlaceBidAsync(auctionId, agent, amount);

            var model = new PlacingBidAgent()
            {
                Amount = amount,
                AuctionId = auctionId,
                BidTime = DateTime.Now,
                UserId = agent

            };
            return View(model);
        }
        [MustBeSeller]
        [HttpGet]
        public IActionResult GetMaxCurrentPrice(int auctionId)
        {
            var updatedMaxCurrentPrice = bidService.GetHighestBidAsync(auctionId);
        return Content(updatedMaxCurrentPrice.ToString());
        }

    }
}
