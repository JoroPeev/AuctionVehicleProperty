using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Core.Models.Vehicles
{
    public class VehicleUpdateServiceModel
    {
        public string Title { get; set; } = string.Empty;

        public string ImageUrls { get; set; } = string.Empty;

        public int VehicleTypeId { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = string.Empty;

        public DateTime Year { get; set; }

        public Category VehicleType { get; set; } = null!;
        public int Mileage { get; set; }

        public int? AverageDivingRange { get; set; }

        public int Power { get; set; }

        public string Color { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;
    }
}
