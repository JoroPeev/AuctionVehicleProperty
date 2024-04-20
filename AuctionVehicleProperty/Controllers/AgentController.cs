using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Agents;
using AuctionVehicleProperty.Extensions;
using Microsoft.AspNetCore.Mvc;
using static AuctionVehicleProperty.Core.Constants.MessageConstants;

namespace AuctionVehicleProperty.Controllers
{
    public class AgentController : BaseController
    {
        private readonly IAgentService agentService;

        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }


        [HttpGet]
        [NotAnSeller]
        public IActionResult Become()
        {
            var model = new AgentServiceModel();

            return View(model);
        }

        [HttpPost]
        [NotAnSeller]
        public async Task<IActionResult> Become(AgentServiceModel model)
        {
            if (!await agentService.ExistsByIdAsync(model.UserId))
            {
                return Unauthorized();
            }

            await agentService.CreateAsync(User.Id(), model.Email, model.Location);

            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }


    }
}
