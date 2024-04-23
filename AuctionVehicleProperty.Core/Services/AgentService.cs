using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Agents;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionVehicleProperty.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;

        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task CreateAsync(string userId, string email, string location)
        {
            await repository.AddAsync(new Agent()
            {
                UserId = userId,
                Email = email,
                Location = location
                
            });

            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(string userId)
        {
            return await repository.AllReadOnly<Agent>()
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<int> GetAgentIdAsync(string userId)
        {
            var agent = await repository.AllReadOnly<Agent>()
         .FirstOrDefaultAsync(a => a.UserId == userId);

            if (agent == null)
            {
               return -1;
            }

            return agent.Id;
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

    }
}
