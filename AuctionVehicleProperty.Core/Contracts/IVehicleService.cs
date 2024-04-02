using AuctionVehicleProperty.Core.Models.Vehicles;

namespace AuctionVehicleProperty.Core.Contracts
{
    public interface IVehicleService
    {
        Task<bool> VehicleExistsByIdAsync(int vehicleId);

        Task<bool> OwnerExistsByIdAsync(int ownerId);

        Task<IEnumerable<VehicleServiceModel>> GetAllVehiclesAsync();

        Task<IEnumerable<VehicleServiceModel>> GetVehiclesByOwnerIdAsync(int ownerId);

        Task<VehicleServiceModel> GetVehicleByIdAsync(int vehicleId);

        Task AddVehicleAsync(VehicleCreationServiceModel vehicle);

        Task UpdateVehicleAsync(int vehicleId, VehicleUpdateServiceModel updatedVehicle);

        Task<VehicleServiceModel> VehicleDetailsByIdAsync(int id);


        Task DeleteVehicleAsync(int vehicleId);
    }
}
