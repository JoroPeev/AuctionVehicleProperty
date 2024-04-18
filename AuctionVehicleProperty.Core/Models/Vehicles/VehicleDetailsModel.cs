using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Core.Models.Vehicles
{
    public class VehicleDetailsModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrls { get; set; } = string.Empty;
        
        public string Make { get; set; } = null!;

        public string Model { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;

        public int OwnerId { get; set; }

    }
}
