using AuctionVehicleProperty.Core.Contracts;
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

        public async Task<IActionResult> Index()
        {
            var vehicles = await vehicleService.GetAllVehiclesAsync();

            return View(vehicles);
        }
    }
}
