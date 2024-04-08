﻿using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Agents;
using AuctionVehicleProperty.Extensions;
using Microsoft.AspNetCore.Mvc;
using static AuctionVehicleProperty.Core.Constants.MessageConstants;

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
            if (await agentService.ExistsByIdAsync(model.UserId))
            {
                ModelState.AddModelError(nameof(model.Email), EmailExists);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await agentService.CreateAsync(User.Id(), model.Email, model.Location);

            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }


    }
}
