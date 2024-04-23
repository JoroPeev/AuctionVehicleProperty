using AuctionVehicleProperty.Core.Models.Agents;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IAgentService
    {
        Task<bool> ExistsByIdAsync(string userId);

        Task CreateAsync(string userId, string email,string location);

        Task<int> GetAgentIdAsync(string userId);

        Task<IEnumerable<AgentServiceModel>> GetAllAgentsAsync();

    }
}
