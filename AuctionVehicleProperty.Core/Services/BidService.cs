using AuctionVehicleProperty.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Services
{
    public class BidService : IBidService
    {
        public Task<bool> AuctionExistsAsync(string auctionId)
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
