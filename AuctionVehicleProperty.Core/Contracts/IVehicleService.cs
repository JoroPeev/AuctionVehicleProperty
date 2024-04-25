using AuctionVehicleProperty.Core.Enumerations;
using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IVehicleService
    {
        Task<VehicleCreationServiceModel?> GetVehicleByIdAsync(int idVehicle);
        Task<IEnumerable<Vehicle>> GetAllAsync(int agentId);
        
        Task<bool> VehicleExistsByIdAsync(int vehicleId);

        Task<bool> OwnerExistsByIdAsync(int ownerId);

        Task<VehicleIndexQueryModel> AllAsync(
           string? category = null,
           string? searchTerm = null,
           VehicleFiltering sorting = VehicleFiltering.Newest,
           int currentPage = 1,
           int vehiclesPerPage = 1);

        Task<VehicleCreationServiceModel> GetVehicleByOwnerIdAsync(int ownerId);

        Task<IEnumerable<VehicleCategoryServiceModel>> AllCategoriesAsync();

        Task<int> AddVehicleAsync(VehicleCreationServiceModel vehicle, int ownerId);

        Task<bool> CategoryExistsAsync(int categoryId);

        Task UpdateVehicleAsync(int vehicleId, VehicleCreationServiceModel updatedVehicle);

        Task<VehicleServiceModel> VehicleDetailsByIdAsync(int id);

        Task<IEnumerable<VehicleServiceModel>> AllVehiclesByAgentIdAsync(int ownerId);

        Task<bool> HasAgentWithIdAsync(int vehicleId, string userId);
        Task DeleteVehicleAsync(int vehicleId);
    }
}
