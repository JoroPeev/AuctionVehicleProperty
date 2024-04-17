using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class IQuerableVehicleExtension
    {
        public static IQueryable<VehicleServiceModel> ProjectToVehicleServiceModel(this IQueryable<Vehicle> vehicles)
        {
            return vehicles
                .Select(h => new VehicleServiceModel()
                {
                    Id = h.Id,
                    Location = h.Location,
                    ImageUrls = h.ImageUrls,
                    Price = h.Price,
                    Title = h.Title,
                    OwnerId = h.OwnerId,
                    
                });
        }
    }
}
