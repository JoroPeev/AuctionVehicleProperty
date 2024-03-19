using AuctionVehicleProperty.Core.Models.Agents;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> AgentWithEmailExistsAsync(string email);

        Task<bool> AgentHasVehiclesAsync(int agentId);

        Task CreateAsync(string userId, string email);

        Task<int?> GetAgentIdAsync(string userId);

        Task<IEnumerable<AgentServiceModel>> GetAllAgentsAsync();

        Task UpdateAgentAsync(int agentId, AgentUpdateServiceModel updatedAgent);

    }
}
