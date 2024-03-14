using AuctionVehicleProperty.Core.Models.Vehicles;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IVehicleService
    {
        Task<bool> VehicleExistsByIdAsync(int vehicleId);

        Task<bool> OwnerExistsByIdAsync(string ownerId);

        Task<IEnumerable<VehicleServiceModel>> GetAllVehiclesAsync();

        Task<IEnumerable<VehicleServiceModel>> GetVehiclesByOwnerIdAsync(string ownerId);

        Task<VehicleServiceModel> GetVehicleByIdAsync(int vehicleId);

        Task AddVehicleAsync(VehicleCreationServiceModel vehicle);

        Task UpdateVehicleAsync(int vehicleId, VehicleUpdateServiceModel updatedVehicle);

        Task DeleteVehicleAsync(int vehicleId);
    }
}
