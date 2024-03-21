namespace AuctionVehicleProperty.Core.Models.Auctions
{
    public class AuctionIndexServiceModel
    {

        public DateTime StartingTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal MinimumBidIncrement { get; set; }

        public decimal StartingPrice { get; set; }

        public int VehicleId { get; set; }

    }
}
