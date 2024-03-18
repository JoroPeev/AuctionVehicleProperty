using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Infrastructure.Data.Common;

namespace AuctionVehicleProperty.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IRepository repository;

        public VehicleService(IRepository _repository)
        {
            repository = _repository;
        }

        public Task AddVehicleAsync(VehicleCreationServiceModel vehicle)
        {
            throw new NotImplementedException();
        }

        public Task DeleteVehicleAsync(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleServiceModel>> GetAllVehiclesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VehicleServiceModel> GetVehicleByIdAsync(int vehicleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VehicleServiceModel>> GetVehiclesByOwnerIdAsync(string ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OwnerExistsByIdAsync(string ownerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateVehicleAsync(int vehicleId, VehicleUpdateServiceModel updatedVehicle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VehicleExistsByIdAsync(int vehicleId)
        {
            throw new NotImplementedException();
        }
    }
}
