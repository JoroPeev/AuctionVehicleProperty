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

        public async Task<bool> AuctionExistAsync(int auctionId)
        {
            return await repository.AllReadOnly<Auction>()
             .AnyAsync(a => a.Id == auctionId);
        }

        public async Task CloseAuctionUserAsync(int auctionId, string winnerId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            if (winnerId != null&&auction!=null)
            {
                auction.WinnerIdUser = winnerId;

                await repository.AddAsync(auction);

                await repository.UpdateAsync(auction);
            }

        }
        public async Task CloseAuctionAgentAsync(int auctionId,int winnerId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);
            
            if (winnerId != 0 && auction != null)
            {
                auction.WinnerIdAgent= winnerId;

                await repository.AddAsync(auction);

                await repository.UpdateAsync(auction);
            }
        
        }


        public async Task CreateAsync(AuctionCreationServiceModel auctionData)
        {
            await repository.AddAsync(new Auction()
            {
               Id = auctionData.Id,
               StartingPrice = auctionData.StartingPrice,
               EndTime = auctionData.EndTime,
               StartingTime = auctionData.StartingTime,
               MinimumBidIncrement = auctionData.MinimumBidIncrement,
               VehicleId = auctionData.VehicleId,
            });

            await repository.SaveChangesAsync();
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
