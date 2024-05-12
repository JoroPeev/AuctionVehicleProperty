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
        public IActionResult RegisterAsAgent()
        {
            var model = new AgentServiceModel() {UserId = User.Id() };

            return View(model);
        }

        [HttpPost]
        [NotAnSeller]
        public async Task<IActionResult> RegisterAsAgent(AgentServiceModel model)
        {
            if (await agentService.ExistsByIdAsync(User.Id()))
            {
                return Unauthorized();
            }
            
            var agents = await agentService.GetAllAgentsAsync();
            
            if (agents.Any(e=>e.Email==model.Email))
            {
                return BadRequest();
            }

            await agentService.CreateAsync(User.Id(), model.Email, model.Location);

            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }


    }
}
