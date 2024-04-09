using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Enumerations;
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
        public async Task<VehicleIndexQueryModel> AllAsync(string? category = null,
            string? searchTerm = null,
            VehicleFiltering sorting = VehicleFiltering.Newest
            , int currentPage = 1, int vehiclesPerPage = 1)
        {
            var vehicles = repository.AllReadOnly<Vehicle>();

            if (category != null)
            {
                vehicles = vehicles.Where(e => e.VehicleType.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                vehicles = vehicles
                    .Where(h => (h.Title.ToLower().Contains(normalizedSearchTerm) ||
                                h.Location.ToLower().Contains(normalizedSearchTerm) ||
                                h.Details.ToLower().Contains(normalizedSearchTerm)));
            }

            vehicles = sorting switch
            {
                VehicleFiltering.Price => vehicles.OrderBy(e => e.Price),
                VehicleFiltering.VehicleType => vehicles.Where(e => e.VehicleType.Name == category),
                _ => vehicles
                     .OrderByDescending(h => h.Id)
            };

            var vehicle = await vehicles
               .Skip((currentPage - 1) * vehiclesPerPage)
               .Take(vehiclesPerPage)
               .ProjectToVehicleServiceModel()
               .ToListAsync();

            int totalVehicles = await vehicles.CountAsync();

            return new VehicleIndexQueryModel()
            {
                Vehicles = vehicle,
                TotalVehiclesCount = totalVehicles
            };
        }

        public async Task<int> AddVehicleAsync(VehicleCreationServiceModel vehicle, int agentId)
        {
            Vehicle car = new Vehicle
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
                OwnerId = agentId,
                Color = vehicle.Color,
            };
            await repository.AddAsync(car);
            await repository.SaveChangesAsync();
            return car.Id;
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            await repository.DeleteEntity<Vehicle>(vehicleId);
        }
        public async Task<bool> CategoryExistsAsync(int categoryId)
        {
            return await repository.AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<VehicleCategoryServiceModel>> AllCategoriesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => new VehicleCategoryServiceModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToListAsync();

        }

        public async Task<VehicleServiceModel> GetVehicleByIdAsync(int vehicleId)
        {

            var vehicle = await repository.GetByIdAsync<VehicleServiceModel>(vehicleId);

            if (vehicle == null)
            {
                throw new VehicleExeption(VehicleNotFound);
            }

            return vehicle;
        }
        public async Task<VehicleServiceModel> VehicleDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Vehicle>()
                .Where(h => h.Id == id)
                .Select(h => new VehicleServiceModel()
                {
                    Id = h.Id,
                    Details = h.Details,
                    ImageUrls = h.ImageUrls,
                    Location = h.Location,
                    Make = h.Make,
                    Mileage = h.Mileage,
                    Model = h.Model,
                    Owner = h.Owner,
                    Price = h.Price,
                    Title = h.Title,
                    VehicleType = h.VehicleType.Name,
                    Year = h.Year,
                })
                .FirstAsync();
        }
        public async Task<VehicleCreationServiceModel> GetVehicleByOwnerIdAsync(int ownerId)
        {
            var vehicle = await repository
                .AllReadOnly<Vehicle>()
                .Where(e => e.OwnerId == ownerId)
                .Select(h => new VehicleCreationServiceModel()
                {
                    Details = h.Details,
                    ImageUrl = h.ImageUrls,
                    Location = h.Location,
                    Make = h.Make,
                    Mileage = h.Mileage,
                    Model = h.Model,
                    OwnerId = h.OwnerId,
                    Price = h.Price,
                    Title = h.Title,
                    VehicleTypeId = h.VehicleTypeId,
                    Year = h.Year,


                })
                .FirstOrDefaultAsync();


            if (vehicle!=null)
            {
               vehicle.VehicleType = await AllCategoriesAsync();
            }


            return vehicle;
        }

        public async Task<bool> OwnerExistsByIdAsync(int ownerId)
        {
            var owner = await repository.GetByIdAsync<Agent>(ownerId);

            if (owner != null)
            {
                return true;
            }

            return false;

        }
        public async Task<bool> HasAgentWithIdAsync(int vehicleId, string userId)
        {
            return await repository.AllReadOnly<Vehicle>()
                .AnyAsync(h => h.Id == vehicleId && h.Owner.UserId == userId);
        }
        public async Task UpdateVehicleAsync(int vehicleId, VehicleCreationServiceModel updatedVehicle)
        {
            var vehicle = await repository.GetByIdAsync<Vehicle>(vehicleId);

            if (vehicle!=null)
            {
                vehicle.Title = updatedVehicle.Title;
                vehicle.ImageUrls = updatedVehicle.ImageUrl;
                vehicle.Year = updatedVehicle.Year;
                vehicle.Make = updatedVehicle.Make;
                vehicle.Model = updatedVehicle.Model;
                vehicle.Mileage = updatedVehicle.Mileage;
                vehicle.Location = updatedVehicle.Location;
                vehicle.AverageDivingRange = updatedVehicle.AverageDivingRange;
                vehicle.Price = updatedVehicle.Price;
                vehicle.Power = updatedVehicle.Power;
                vehicle.Details = updatedVehicle.Details;
                vehicle.VehicleTypeId = updatedVehicle.VehicleTypeId;
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

        public async Task<IEnumerable<VehicleServiceModel>> AllVehiclesByAgentIdAsync(int ownerId)
        {
            return await repository.AllReadOnly<Vehicle>()
                  .Where(h => h.OwnerId == ownerId)
                  .ProjectToVehicleServiceModel()
                  .ToListAsync();
        }
    }
}
