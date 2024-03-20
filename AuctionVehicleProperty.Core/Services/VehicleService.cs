using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AuctionVehicleProperty.Core.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly IRepository repository;

        public VehicleService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task AddVehicleAsync(VehicleCreationServiceModel vehicle)
        {
            await repository.AddAsync(new Vehicle
            {
                Title = vehicle.Title,
                ImageUrls = vehicle.ImageUrl,
                VehicleTypeId = vehicle.VehicleTypeId,
                Make = vehicle.Make,
                Model = vehicle.Model,
                Year = vehicle.Year,
                Mileage = vehicle.Mileage,
                AverageDivingRange = vehicle.AverageDivingRange,
                Power = vehicle.Power,
                Price = vehicle.Price,
                Location = vehicle.Location,
                Details = vehicle.Details,
                Id = vehicle.Id,
                OwnerId = vehicle.OwnerId,
                Color = vehicle.Color
            });

            await repository.SaveChangesAsync();
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            await repository.DeleteEntity<Vehicle>(vehicleId);
        }

        public async Task<IEnumerable<VehicleServiceModel>> GetAllVehiclesAsync()
        {
            return await repository.AllReadOnly<Vehicle>().Select(v => new VehicleServiceModel
            {
                Id = v.Id,
                Make = v.Make,
                Model = v.Make,
                Title = v.Title,
                ImageUrls = v.ImageUrls

            }).ToListAsync();
        }

        public async Task<VehicleServiceModel> GetVehicleByIdAsync(int vehicleId)//Do not forget to implement try catch
        {

            var vehicle = await repository.GetByIdAsync<VehicleServiceModel>(vehicleId);

            if (vehicle == null)
            {
                throw new InvalidDataException("Invalid Vehicle");
            }

            return vehicle;
        }

        public Task<IEnumerable<VehicleServiceModel>> GetVehiclesByOwnerIdAsync(int ownerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> OwnerExistsByIdAsync(int ownerId)
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
