using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Core.Models.Auctions
{
    public class AuctionBidServiceModel
    {
        public int Id { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal StartingPrice { get; set; }

        public decimal MinimumBidIncrement { get; set; }

        public int? WinnerID { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; } = null!;

        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }


}

