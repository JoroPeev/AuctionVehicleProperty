using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Bids;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

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
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            if (auction != null)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> CanPlaceBidAsync(string userId, int auctionId, decimal amount)
        {
            var user = await repository.GetByIdAsync<IdentityUser>(userId);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        public async Task<decimal?> GetHighestBidAsync(int auctionId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            var bid = auction.Bids.Max(e => e.Amount);

            return bid;

        }


        public async Task PlaceBidAsync(int auctionId, string userId, decimal amount)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            if (auction != null)
            {
                var currentHighestBid = await repository.AllReadOnly<Bid>()
                                          .Where(e => e.AuctionId == auctionId)
                                          .Select(e => e.Amount)
                                          .DefaultIfEmpty()
                                          .MaxAsync();
                if (amount > currentHighestBid)
                {
                    var bid = new Bid()
                    {
                        Amount = amount,
                        BidTime = DateTime.Now,
                        CustomerId = userId,
                        AuctionId = auctionId,

                    };

                    auction.Bids.Add(bid);

                    await repository.UpdateAsync(auction);
                }
            }

        }

        public async Task<IEnumerable<BidHistoryServiceModel>> GetBidHistoryAsync(int auctionId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            var bidHistory = auction.Bids.Select(bid => new BidHistoryServiceModel
            {
                Amount = bid.Amount,
                BidTime = bid.BidTime,
                UserId = bid.CustomerId,
            });

            return bidHistory;

        }


        public async Task<bool> UserExistsAsync(string userId)
        {
            return await repository.AllReadOnly<IdentityUser>()
             .AnyAsync(a => a.Id == userId);
        }

        public async Task<bool> VehicleExistsAsync(int vehicleId)
        {
            return await repository.AllReadOnly<Vehicle>()
             .AnyAsync(a => a.Id == vehicleId);
        }
    }
}
