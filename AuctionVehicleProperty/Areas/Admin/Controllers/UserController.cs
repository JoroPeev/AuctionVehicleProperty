using AuctionVehicleProperty.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService)
        {
            userService = _userService;   
        }


        public async Task<IActionResult> All()
        {
            var model = await userService.AllAsync();

            return View(model);
        }
    }
}
