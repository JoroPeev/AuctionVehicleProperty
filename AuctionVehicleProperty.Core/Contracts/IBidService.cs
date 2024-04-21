using AuctionVehicleProperty.Core.Models.Bids;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IBidService
    {
        Task<bool> AuctionExistsAsync(string auctionId);

        Task<bool> UserExistsAsync(string userId);

        Task<bool> VehicleExistsAsync(int vehicleId);

        Task<decimal?> GetHighestBidAsync(int auctionId);

        Task<IEnumerable<BidHistoryServiceModel>> GetBidHistoryAsync(int auctionId);

        Task PlaceBidAsync(int auctionId, int agentId, decimal amount);

        Task<bool> CanPlaceBidAsync(int agentId);
    }
}
