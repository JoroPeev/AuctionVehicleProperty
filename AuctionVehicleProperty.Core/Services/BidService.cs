﻿using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Exeptions;
using AuctionVehicleProperty.Core.Models.Bids;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static AuctionVehicleProperty.Core.Exeptions.ExeptionMessages;

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

            if (user==null)
            {
                throw new UserNotFoundExeption(UserNotFound);
            }

            if (user.EmailConfirmed)
            {
                return true;
            }

            return false;
        }

        public async Task<decimal?> GetHighestBidAsync(int auctionId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            if (auction == null)
            {
                throw new AuctionExeption(AuctionNotFound);
            }

            
           var bid = auction.Bids.Max(e=>e.Amount);

            return bid;


        }


        public async Task PlaceBidAsync(int auctionId, string userId, decimal amount)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            if (auction == null)
            {
                throw new InvalidOperationException(AuctionNotFound);
            }

            var currentHighestBid = await repository.AllReadOnly<Bid>()
                                         .Where(e => e.AuctionId == auctionId)
                                         .Select(e => e.Amount)
                                         .DefaultIfEmpty()
                                         .MaxAsync();


            if (amount <= currentHighestBid)
            {
                throw new InvalidOperationException(AuctionBiding);
            }

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

        public async Task<IEnumerable<BidHistoryServiceModel>> GetBidHistoryAsync(int auctionId)
        {
            var auction = await repository.GetByIdAsync<Auction>(auctionId);

            if (auction != null)
            {
                var bidHistory = auction.Bids.Select(bid => new BidHistoryServiceModel
                {
                    Amount = bid.Amount,
                    BidTime = bid.BidTime,
                    UserId = bid.CustomerId,
                });

                return bidHistory;
            }
            else
            {
                throw new InvalidOperationException(AuctionBiding);
            }
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
