using Microsoft.AspNetCore.Mvc;

namespace AuctionVehicleProperty.Areas.Admin.Componets
{
    namespace HouseRentingSystem.Areas.Admin.Components
    {
        public class AdminMenuComponent : ViewComponent
        {
            public async Task<IViewComponentResult> InvokeAsync()
            {
                return await Task.FromResult<IViewComponentResult>(View());
            }
        }
    }
}
