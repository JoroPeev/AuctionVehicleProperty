using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IBidService
    {
        Task<bool> AuctionExistsAsync(string auctionId);

        Task<bool> UserExistsAsync(string userId);
        
        Task<bool> VehicleExistsAsync(string vehicleId);
    }
}
