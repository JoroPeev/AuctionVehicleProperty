using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IAgentService agentService;
        public VehicleController(IVehicleService _vehicleService,IAgentService _agentService)
        {
            agentService = _agentService;
            vehicleService = _vehicleService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] VehicleIndexQueryModel model)
        {
            var vehicles = await vehicleService.AllAsync(
                model.Category,
                model.SearchTerm,
                model.Sorting,
                model.CurrentPage,
                model.VehiclesPerPage
                );

            model.TotalVehiclesCount = vehicles.TotalVehiclesCount;
            model.Vehicles = vehicles.Vehicles;
            model.Categories = await vehicleService.AllCategoriesAsync();

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            if (await vehicleService.VehicleExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await vehicleService.VehicleDetailsByIdAsync(id);

            return View(model);
        }
        [HttpGet]
        [MustBeSeller]
        public async Task<IActionResult> Add()
        {
            var model = new VehicleCreationServiceModel()
            {
                VehicleType = await vehicleService.AllCategoriesAsync(),
            };

            return View(model);
        }

        [HttpPost]
        [MustBeSeller]
        public async Task<IActionResult> Add(VehicleCreationServiceModel vehicle)
        {
            if (await vehicleService.CategoryExistsAsync(vehicle.VehicleTypeId) == false)
            {
                ModelState.AddModelError(nameof(vehicle.VehicleTypeId), "Category does not exist");
            }

            if (ModelState.IsValid == false)
            {
                vehicle.VehicleType = await vehicleService.AllCategoriesAsync();

                return View(vehicle);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newVehicleId = await vehicleService.AddVehicleAsync(vehicle,agentId ?? 0);

            return RedirectToAction(nameof(Details));
        }


    }
}
