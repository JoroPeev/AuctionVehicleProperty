using AuctionVehicleProperty.Areas.Admin.Controllers.AuctionVehicleProperty.Areas.Admin.Controllers;
using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Areas.Admin.Controllers
{
    public class VehicleController : AdminBaseController
    {
        private readonly IVehicleService vehicleService;

        private readonly IAgentService agentService;

        public VehicleController(
            IVehicleService _vehicleService,
            IAgentService _agentService)
        {
            vehicleService = _vehicleService;
            agentService = _agentService;
        }
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            int agentId = await agentService.GetAgentIdAsync(userId);

            if (agentId == -1) 
            {
                return BadRequest();
            }

            var myVehicles = new MyVehiclesViewModel()
            {
                AddedVehicles = await vehicleService.AllVehiclesByAgentIdAsync(agentId),
            };

            return View(myVehicles);
        }
    }
}
