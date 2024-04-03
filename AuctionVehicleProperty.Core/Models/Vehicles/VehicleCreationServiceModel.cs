using AuctionVehicleProperty.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Models.Vehicles
{
    public class VehicleCreationServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public int VehicleTypeId { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = string.Empty;

        public DateTime Year { get; set; }

        public int Mileage { get; set; }

        public Category VehicleType { get; set; } = null!;

        public int? AverageDivingRange { get; set; }

        public int Power { get; set; }

        public string Color { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string Location { get; set; } = string.Empty;

        public string Details { get; set; } = string.Empty;

        public int OwnerId { get; set; }


    }
}
