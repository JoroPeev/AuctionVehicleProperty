using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Bids;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Core.Services
{
    public class BidService : IBidService
    {
        private readonly IRepository repository;

        public BidService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<bool> AuctionExistsAsync(string auctionId)
        {
            var vehicle = await repository.GetByIdAsync<Auction>(auctionId);

            if (vehicle != null)
            {
                return true;
            }
         
            return false;
        
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
