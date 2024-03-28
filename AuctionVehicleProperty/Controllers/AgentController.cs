using AuctionVehicleProperty.Core.Contracts;
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


        public IActionResult BecomeAgent()
        {
            return View();
        }

       
    }
}
