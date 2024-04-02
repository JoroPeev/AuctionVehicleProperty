using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Models.Vehicles
{
    public class VehicleServiceModel
    {
        public int Id { get; set; }
      
        public string Title { get; set; } = string.Empty;

        public string ImageUrls { get; set; } = string.Empty;

        public int VehicleTypeId { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = string.Empty;

        public DateTime Year { get; set; }

        public int Mileage { get; set; }

        public decimal Price { get; set; }

        public string Location { get; set; } = string.Empty;

        public int OwnerId { get; set; }
         
        public Agent Owner { get; set; } = null!;
        public string Details { get; set; } = string.Empty;



    }
}
