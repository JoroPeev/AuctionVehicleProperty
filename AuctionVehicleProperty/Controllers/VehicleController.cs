using AuctionVehicleProperty.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Controllers
{
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;

        public VehicleController(IVehicleService _vehicleService)
        {
            vehicleService = _vehicleService;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var vehicles = await vehicleService.GetAllVehiclesAsync();

            return View(vehicles);
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



    }
}
