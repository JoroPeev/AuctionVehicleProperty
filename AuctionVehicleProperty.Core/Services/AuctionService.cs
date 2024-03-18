using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Auctions;
using AuctionVehicleProperty.Infrastructure.Data.Common;

namespace AuctionVehicleProperty.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IRepository repository;

        public AuctionService(IRepository _repository)
        {
            repository = _repository;
        }
        public Task<IEnumerable<AuctionIndexServiceModel>> AllAuctionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> AuctionExistAsync(int auctionId)
        {
            throw new NotImplementedException();
        }

        public Task CloseAuctionAsync(int auctionId)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(string userId, string email, AuctionCreationServiceModel auctionData)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuctionIndexServiceModel>> CurrentAuctionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuctionBidServiceModel>> GetAuctionBidsAsync(int auctionId)
        {
            throw new NotImplementedException();
        }

        public Task<AuctionCreationServiceModel> GetAuctionDetailsAsync(int auctionId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuctionIndexServiceModel>> LatestAuctionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task PlaceBidAsync(int auctionId, string userId, decimal amount)
        {
            throw new NotImplementedException();
        }
    }
}
