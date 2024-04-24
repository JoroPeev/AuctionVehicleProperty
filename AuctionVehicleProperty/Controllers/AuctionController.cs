using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Auctions;
using AuctionVehicleProperty.Extensions;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class AuctionController : BaseController
    {
        private readonly IVehicleService vehicleService;
        private readonly IAgentService agentService;
        private readonly IAuctionService actionService;
        public AuctionController(IVehicleService _vehicleService, IAgentService _agentService, IAuctionService _actionService)
        {
            agentService = _agentService;
            vehicleService = _vehicleService;
            actionService = _actionService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var auction = await actionService.AllAuctionsAsync();
            return View(auction);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (!await actionService.AuctionExistAsync(id))
            {
                return BadRequest();
            }

            var auction = await actionService.GetAuctionDetailsAsync(id);


            return View(auction);
        }
        [HttpGet]
        [MustBeSeller]
        public async Task<IActionResult> Create(int ownerId)
        {
            int? id = await agentService.GetAgentIdAsync(User.Id());

            if (id != ownerId)
            {
                return Unauthorized();
            }

            var vehicles = await vehicleService.GetAllAsync(ownerId);

            var model = new AuctionCreationServiceModel
            {
                Vehicles = vehicles,
                CreatorId = ownerId,
                
            };

            return View(model);
        }

        [HttpPost]
        [MustBeSeller]
        public async Task<IActionResult> Create(AuctionCreationServiceModel auction)
        {
            if (!(await vehicleService.HasAgentWithIdAsync(auction.VehicleId, User.Id())))
            {
                return BadRequest();

            }
            if (await actionService.VehicleExistsInOtherAuctionsAsync(auction.VehicleId))
            {
                return BadRequest();
            }
            var vehicles = await actionService.AllAuctionsAsync();
            if(vehicles.Any(e=>e.Id==auction.VehicleId))
            {
                return BadRequest();
            }
            if (await actionService.AuctionExistAsync(auction.Id))
            {
                return BadRequest();
            }
            await actionService.CreateAsync(auction);

            return RedirectToAction(nameof(AuctionController.Index));
        }
        [HttpGet]
        [Route("Auction/Delete/{auctionId:int}")]
        public async Task<IActionResult> Delete(int auctionId)
        {
            if (await actionService.AuctionExistAsync(auctionId) == false)
            {
                return BadRequest();
            }
            var auction = await actionService.GetAuctionDetailsAsync(auctionId);

            if (await actionService.AuctionValidationCreator(auctionId, User.Id()) == false)
            {
                return Unauthorized();
            }


            var model = new AuctionDetailsModel()
            {
                Id = auctionId,
                StartingPrice = auction.StartingPrice,
                StartingTime = auction.StartingTime,
                CreatorId = auction.CreatorId,
                EndTime = auction.EndTime,
                Bids = auction.Bids,
                MinimumBidIncrement = auction.MinimumBidIncrement,
                Vehicle = auction.Vehicle,
                VehicleId = auction.VehicleId,
                WinnerIdAgent = auction.WinnerIdAgent

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(AuctionDetailsModel model)
        {
            if (await actionService.AuctionExistAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (await actionService.AuctionValidationCreator(model.Id, User.Id()) == false)
            {
                return Unauthorized();  
            }

            await actionService.DeleteAuctionAsync(model.Id);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id, AuctionCreationServiceModel auction)
        {
            var allascions = await actionService.AllAuctionsAsync();
            if (allascions.Any(e=>e.Id==auction.Id))
            {
                return BadRequest();
            }

            if (await actionService.AuctionValidationCreator(auction.Id,User.Id()))
            {
                return Unauthorized();
            }

            await actionService.UpdateAuctionAsync(auction);

            return RedirectToAction(nameof(AuctionController.Index), "Auction");
        }


    }
}
