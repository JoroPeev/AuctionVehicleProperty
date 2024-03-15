using AuctionVehicleProperty.Core.Models.Agents;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task<bool> UserWithEmailExistsAsync(string email);

        Task<bool> UserHasVehiclesAsync(string userId);

        Task CreateAsync(string userId, string email);

        Task<int?> GetAgentIdAsync(string userId);

        Task<IEnumerable<AgentServiceModel>> GetAllAgentsAsync();

        Task<AgentServiceModel> GetAgentByIdAsync(int agentId);

        Task UpdateAgentAsync(int agentId, AgentUpdateServiceModel updatedAgent);

        Task DeleteAgentAsync(int agentId);

    }
}
