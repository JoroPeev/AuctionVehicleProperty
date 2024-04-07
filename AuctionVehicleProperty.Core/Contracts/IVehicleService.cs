using AuctionVehicleProperty.Core.Enumerations;
using AuctionVehicleProperty.Core.Models.Vehicles;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IVehicleService
    {
        Task<bool> VehicleExistsByIdAsync(int vehicleId);

        Task<bool> OwnerExistsByIdAsync(int ownerId);

        Task<VehicleIndexQueryModel> AllAsync(
           string? category = null,
           string? searchTerm = null,
           VehicleFiltering sorting = VehicleFiltering.Newest,
           int currentPage = 1,
           int housesPerPage = 1);

        Task<IEnumerable<VehicleServiceModel>> GetVehiclesByOwnerIdAsync(int ownerId);

        Task<IEnumerable<VehicleCategoryServiceModel>> AllCategoriesAsync();

        Task<VehicleServiceModel> GetVehicleByIdAsync(int vehicleId);

        Task<int> AddVehicleAsync(VehicleCreationServiceModel vehicle, int agentId);

        Task<bool> CategoryExistsAsync(int categoryId);

        Task UpdateVehicleAsync(int vehicleId, VehicleUpdateServiceModel updatedVehicle);

        Task<VehicleServiceModel> VehicleDetailsByIdAsync(int id);


        Task DeleteVehicleAsync(int vehicleId);
    }
}
