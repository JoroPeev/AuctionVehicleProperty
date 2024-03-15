using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Bids;

namespace AuctionVehicleProperty.Core.Services
{
    public class BidService : IBidService
    {
        public Task<bool> AuctionExistsAsync(string auctionId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CanPlaceBidAsync(string userId, string auctionId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BidHistoryServiceModel>> GetBidHistoryAsync(string auctionId)
        {
            throw new NotImplementedException();
        }

        public Task<decimal?> GetHighestBidAsync(string auctionId)
        {
            throw new NotImplementedException();
        }

        public Task PlaceBidAsync(string userId, string auctionId, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserExistsAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VehicleExistsAsync(string vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
