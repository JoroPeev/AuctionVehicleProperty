using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Core.Models.Auctions
{
    public class AuctionIndexServiceModel
    {
        public int Id { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal MinimumBidIncrement { get; set; }

        public decimal StartingPrice { get; set; }

        public int CreatorId { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; } = null!;

    }
}
