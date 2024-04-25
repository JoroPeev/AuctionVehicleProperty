using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class VehicleController : BaseController
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
                ModelState.AddModelError(nameof(vehicle.VehicleTypeId), "Vehicle type does not exist");
            }

            if (ModelState.IsValid == false)
            {
                vehicle.VehicleType = await vehicleService.AllCategoriesAsync();

                return View(vehicle);
            }

            int? agentId = await agentService.GetAgentIdAsync(User.Id());

            int newVehicleId = await vehicleService.AddVehicleAsync(vehicle,agentId ?? 0);

            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int idVehicle)
        {
            if (await vehicleService.VehicleExistsByIdAsync(idVehicle) == false 
                && User.IsAdmin() == false)
            {
                return BadRequest();
            }

            if (await vehicleService.HasAgentWithIdAsync(idVehicle, User.Id()) == false 
                && User.IsAdmin() == false)

            {
                return Unauthorized();
            }

            var model = await vehicleService.GetVehicleByIdAsync(idVehicle);

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(VehicleCreationServiceModel car)
        {

            if (await vehicleService.VehicleExistsByIdAsync(car.Id) == false)
            {

                return BadRequest();
            }

            if (await vehicleService.HasAgentWithIdAsync(car.Id, User.Id()) == false)
            {
                return Unauthorized();
            }

            if (await vehicleService.CategoryExistsAsync(car.VehicleTypeId) == false)
            {
                ModelState.AddModelError(nameof(car.VehicleTypeId), "Vehicle type does not exist");
            }

            if (ModelState.IsValid == false)
            {
                car.VehicleType = await vehicleService.AllCategoriesAsync();

                return View(car);
            }

            await vehicleService.UpdateVehicleAsync(car.Id, car);

            return RedirectToAction(nameof(VehicleController.Index), "Vehicle");
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = User.Id();
            IEnumerable<VehicleServiceModel> model = Enumerable.Empty<VehicleServiceModel>();

            if (User.IsAdmin())
            {
                return RedirectToAction("Mine", "Vehicle", new { area = "Admin" });
            }

            if (await agentService.ExistsByIdAsync(userId))
            {
                int agentId = await agentService.GetAgentIdAsync(userId);
                model = await vehicleService.AllVehiclesByAgentIdAsync(agentId);
            }

            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await vehicleService.VehicleExistsByIdAsync(id) == false)
            {
                return BadRequest();
            }

            if (await vehicleService.HasAgentWithIdAsync(id, User.Id()) == false)
            {
                return Unauthorized();
            }

            var vehicle = await vehicleService.VehicleDetailsByIdAsync(id);

            var model = new VehicleDetailsModel()
            {
                Id = id,
                Title = vehicle.Title,
                ImageUrls = vehicle.ImageUrls,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Price = vehicle.Price,
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(VehicleDetailsModel model)
        {
            if (await vehicleService.VehicleExistsByIdAsync(model.Id) == false 
                && User.IsAdmin() == false)
            {
                return BadRequest();
            }

            if (await vehicleService.HasAgentWithIdAsync(model.Id, User.Id()) == false 
                && User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await vehicleService.DeleteVehicleAsync(model.Id);

            return RedirectToAction(nameof(Index));
        }
        

    }
}
