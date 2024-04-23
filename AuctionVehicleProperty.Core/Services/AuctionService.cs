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
                Id = a.Id,
                Vehicle = a.Vehicle,
                EndTime = a.EndTime,
                StartingPrice = a.StartingPrice,
                StartingTime = a.StartingTime,
                MinimumBidIncrement = a.MinimumBidIncrement,
                CreatorId = a.CreatorId



            }).ToListAsync();
        }

        public async Task<bool> VehicleExistsInOtherAuctionsAsync(int vehicleId)
        {
            var otherAuctions = await repository.All<Auction>()
                .Where(a => a.VehicleId == vehicleId && a.Id != vehicleId)
                .ToListAsync();

            return otherAuctions.Any();
        }

        public async Task<bool> AuctionValidationCreator(int auctionId, string creatorId)
        {
            var owner =  repository.AllReadOnly<Agent>().FirstOrDefault(e=>e.UserId==creatorId);

            if (owner==null)
            {
                return false;
            }

            return await repository.AllReadOnly<Auction>().Where(e => e.CreatorId == owner.Id)
                 .AnyAsync(a => a.Id == auctionId);
        }

        public async Task<bool> AuctionExistAsync(int auctionId)
        {
            return await repository.AllReadOnly<Auction>()
             .AnyAsync(a => a.Id == auctionId);
        }

        public async Task CreateAsync(AuctionCreationServiceModel auctionData)
        {
            await repository.AddAsync(new Auction()
            {
                Id = auctionData.Id,
                StartingPrice = auctionData.StartingPrice,
                EndTime = auctionData.EndTime,
                StartingTime = DateTime.Now,
                MinimumBidIncrement = auctionData.MinimumBidIncrement,
                VehicleId = auctionData.VehicleId,
                CreatorId = auctionData.CreatorId
            });

            await repository.SaveChangesAsync();
        }

        public async Task<ICollection<Bid>> GetAuctionBidsAsync(int auctionId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            return auction.Bids;

        }

        public async Task<AuctionDetailsModel> GetAuctionDetailsAsync(int auctionId)
        {
            var a = await repository.GetByIdAsync<Auction>(auctionId);

            var vehicle = await repository.GetByIdAsync<Vehicle>(a.VehicleId);

            var auctionIndexServiceModels = new AuctionDetailsModel
            {
                EndTime = a.EndTime,
                StartingTime = a.StartingTime,
                MinimumBidIncrement = a.MinimumBidIncrement,
                StartingPrice = a.StartingPrice,
                VehicleId = a.VehicleId,
                Bids = a.Bids,
                Id = a.Id,
                Vehicle = vehicle,
                CreatorId = a.CreatorId,
                
            };

            return auctionIndexServiceModels;
        }

        public async Task DeleteAuctionAsync(int auctionId)
        {
            await repository.DeleteEntity<Auction>(auctionId);
        }
    }
}
