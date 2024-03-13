using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Auctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Services
{
    public class AuctionService : IAuctionService
    {
        public Task<IEnumerable<AuctionIndexServiceModel>> LatestAuctionsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
