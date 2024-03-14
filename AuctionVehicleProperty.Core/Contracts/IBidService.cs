using AuctionVehicleProperty.Core.Models.Bids;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IBidService
    {
        Task<bool> AuctionExistsAsync(string auctionId);

        Task<bool> UserExistsAsync(string userId);

        Task<bool> VehicleExistsAsync(string vehicleId);

        Task<decimal?> GetHighestBidAsync(string auctionId);

        Task<IEnumerable<BidHistoryServiceModel>> GetBidHistoryAsync(string auctionId);

        Task PlaceBidAsync(string userId, string auctionId, decimal amount);

        Task<bool> CanPlaceBidAsync(string userId, string auctionId, decimal amount);
    }
}
