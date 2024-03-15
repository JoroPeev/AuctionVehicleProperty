using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Agents;
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

        public Task DeleteAgentAsync(int agentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AgentServiceModel> GetAgentByIdAsync(int agentId)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetAgentIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AgentServiceModel>> GetAllAgentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAgentAsync(int agentId, AgentUpdateServiceModel updatedAgent)
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
