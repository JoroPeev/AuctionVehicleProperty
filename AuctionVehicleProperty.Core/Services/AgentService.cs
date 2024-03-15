using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Agents;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string email)
        {
            await repository.AddAsync(new Agent()
            {
                UserId = userId,
                Email = email
            });

            await repository.SaveChangesAsync();
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
