namespace AuctionVehicleProperty.Core.Models.Bids
{
    public class BidHistoryServiceModel
    {
        public string UserId { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }
    }
}
