using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Auctions;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class AuctionController : Controller
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
        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            if (await actionService.AuctionExistAsync(id))
            {
                return BadRequest();
            }

            var auction = actionService.

            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
