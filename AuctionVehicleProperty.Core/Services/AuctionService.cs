using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Exeptions;
using AuctionVehicleProperty.Core.Models.Auctions;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static AuctionVehicleProperty.Core.Exeptions.ExeptionMessages;

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

            if (winnerId != null && auction != null)
            {
                auction.WinnerIdUser = winnerId;

                await repository.AddAsync(auction);

                await repository.UpdateAsync(auction);
            }

        }
        public async Task CloseAuctionAgentAsync(int auctionId, int winnerId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            if (winnerId != 0 && auction != null)
            {
                auction.WinnerIdAgent = winnerId;

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
                StartingTime = DateTime.Now,
                MinimumBidIncrement = auctionData.MinimumBidIncrement,
                VehicleId = auctionData.VehicleId,
            });

            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AuctionIndexServiceModel>> CurrentAuctionsAsync()
        {
            var auctions = await repository.AllReadOnly<Auction>().ToListAsync();

            var auctionIndexServiceModels = auctions.Select(a =>
                new AuctionIndexServiceModel
                {
                    EndTime = a.EndTime,
                    StartingTime = a.StartingTime,
                    MinimumBidIncrement = a.MinimumBidIncrement,
                    StartingPrice = a.StartingPrice,
                    VehicleId = a.VehicleId
                });

            return auctionIndexServiceModels;
        }

        public async Task<ICollection<Bid>> GetAuctionBidsAsync(int auctionId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            return auction.Bids;

        }

        public async Task<AuctionDetailsModel> GetAuctionDetailsAsync(int auctionId)
        {
            var a = await repository.GetByIdAsync<Auction>(auctionId);

            var auctionIndexServiceModels = new AuctionDetailsModel
            {
                EndTime = a.EndTime,
                StartingTime = a.StartingTime,
                MinimumBidIncrement = a.MinimumBidIncrement,
                StartingPrice = a.StartingPrice,
                VehicleId = a.VehicleId,
                Bids = a.Bids,
                Id = a.Id,
                Vehicle = a.Vehicle
            };

            return auctionIndexServiceModels;
        }

        public async Task<IEnumerable<AuctionIndexServiceModel>> LatestAuctionsAsync()
        {
            var auctionIndices = await repository.AllReadOnly<Auction>()
                .Select(h => new AuctionIndexServiceModel()
                {
                    VehicleId = h.VehicleId,
                    StartingPrice = h.StartingPrice,
                    StartingTime = h.StartingTime,
                    EndTime = h.EndTime,
                    MinimumBidIncrement = h.MinimumBidIncrement

                }).ToListAsync();

            return auctionIndices;

        }
    }
}
