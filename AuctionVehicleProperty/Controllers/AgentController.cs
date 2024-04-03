using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Agents;
using AuctionVehicleProperty.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class AgentController : Controller
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
            if (await agentService.GetAgentIdAsync(model.UserId)==null)
            {
                ModelState.AddModelError(nameof(VehicleController.Index), "Agent");
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await agentService.CreateAsync(model.UserId,model.Email);

            return RedirectToAction(nameof(VehicleController.Index), "Agent");
        }


    }
}
