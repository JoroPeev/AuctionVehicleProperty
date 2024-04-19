using AuctionVehicleProperty.Core.Models.Vehicles;

namespace AuctionVehicleProperty.Areas.Admin
{
    public class MyVehiclesViewModel
    {
        public IEnumerable<VehicleServiceModel> AddedVehicles { get; set; } = new List<VehicleServiceModel>();
    }
}
