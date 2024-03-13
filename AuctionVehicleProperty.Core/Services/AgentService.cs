using AuctionVehicleProperty.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Services
{
    public class AgentService : IAgentService
    {
        public Task CreateAsync(string userId, string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetAgentIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserHasVehiclesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UserWithEmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
