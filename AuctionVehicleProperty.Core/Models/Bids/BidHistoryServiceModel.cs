namespace AuctionVehicleProperty.Core.Models.Bids
{
    public class BidHistoryServiceModel
    {
        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }
    }
}
