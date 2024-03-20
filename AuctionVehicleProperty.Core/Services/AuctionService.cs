using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Auctions;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionVehicleProperty.Core.Services
{
    public class AuctionService : IAuctionService
    {
        private readonly IRepository repository;

        public AuctionService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<AuctionIndexServiceModel>> AllAuctionsAsync()
        {
            return await repository.AllReadOnly<Auction>().Select(a => new AuctionIndexServiceModel
            {
                VehicleId = a.VehicleId,
                EndTime = a.EndTime,
                StartingPrice = a.StartingPrice,
                StartingTime = a.StartingTime,
                MinimumBidIncrement = a.MinimumBidIncrement


            }).ToListAsync();
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
