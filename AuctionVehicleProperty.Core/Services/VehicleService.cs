using AuctionVehicleProperty.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Services
{
    public class VehicleService : IVehicleService
    {
        public Task<bool> OwnerExistsByIdAsync(string ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VehicleExistsByIdAsync(int vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
