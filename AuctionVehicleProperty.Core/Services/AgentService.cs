using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Agents;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Agent>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int?> GetAgentByIdAsync(int agentId)
        {
            return (await repository.AllReadOnly<Agent>()
            .FirstOrDefaultAsync(a => a.Id == agentId))?.Id;
        }

        public async Task<int?> GetAgentIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Agent>()
            .FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
        }

        public async Task<IEnumerable<AgentServiceModel>> GetAllAgentsAsync()
        {
            return await repository.AllReadOnly<Agent>().Select(a => new AgentServiceModel()
            {
                Id = a.Id,
                Email = a.Email,
                Location = a.Location,
                Vehicles = a.Vehicles,
                UserId = a.UserId,

            }).ToListAsync();
        }

        public async Task UpdateAgentAsync(int agentId, AgentUpdateServiceModel updatedAgent)
        {
            var agent = await repository.GetByIdAsync<Agent>(agentId);

            if (agent != null)
            {
                agent.Email = updatedAgent.Email;
                agent.Location = updatedAgent.Location;
                agent.Vehicles = updatedAgent.Vehicles;
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> UserHasVehiclesAsync(string userId)
        {

            throw new NotImplementedException();
        }

        public Task<bool> UserWithEmailExistsAsync(string email)
        {
            throw new NotImplementedException();
        }

        Task<AgentServiceModel> IAgentService.GetAgentByIdAsync(int agentId)
        {
            throw new NotImplementedException();
        }
    }
}
