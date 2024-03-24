using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Exeptions;
using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using static AuctionVehicleProperty.Core.Exeptions.ExeptionMessages;

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
                throw new VehicleExeption(VehicleNotFound);
            }

            return vehicle;
        }

        public async Task<IEnumerable<VehicleServiceModel>> GetVehiclesByOwnerIdAsync(int ownerId)
        {
            return await repository
                .AllReadOnly<VehicleServiceModel>()
                .Where(e => e.OwnerId == ownerId)
                .ToListAsync();
        }

        public async Task<bool> OwnerExistsByIdAsync(int ownerId)
        {
           var owner = await repository.GetByIdAsync<Agent>(ownerId);

            if (owner!=null)
            {
                return true;
            }

            return false;

        }

        public async Task UpdateVehicleAsync(int vehicleId, VehicleUpdateServiceModel updatedVehicle)
        {
            var vehicle = await repository.GetByIdAsync<Vehicle>(vehicleId);

            if (vehicle != null)
            {
                vehicle.Title = updatedVehicle.Title;
            }
            else
            {
                throw new VehicleExeption(VehicleNotFound);
            }

            await repository.SaveChangesAsync();
        }

        public async Task<bool> VehicleExistsByIdAsync(int vehicleId)
        {
            var vehicle = await repository.GetByIdAsync<Vehicle>(vehicleId);

            if (vehicle != null)
            {
                return true;
            }

            return false;
        }
    }
}
