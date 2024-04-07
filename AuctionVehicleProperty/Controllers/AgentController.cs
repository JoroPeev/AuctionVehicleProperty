using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Agents;
using AuctionVehicleProperty.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, model.Email),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }


    }
}
