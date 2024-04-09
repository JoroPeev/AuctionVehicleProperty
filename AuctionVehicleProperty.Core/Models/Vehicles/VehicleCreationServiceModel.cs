using AuctionVehicleProperty.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AuctionVehicleProperty.Infrastructure.Constants.DataConstants;
using static AuctionVehicleProperty.Core.Constants.MessageConstants;

namespace AuctionVehicleProperty.Core.Models.Vehicles
{
    public class VehicleCreationServiceModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleTitleMax,
           MinimumLength = VehicleTitleMin,
           ErrorMessage = LengthMessage)]
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;


        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleMakeMax,
           MinimumLength = VehicleMakeMin,
           ErrorMessage = LengthMessage)]
        public string Make { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleModelMax,
           MinimumLength = VehicleModelMin,
           ErrorMessage = LengthMessage)]
        public string Model { get; set; } = string.Empty;
       
        [Required(ErrorMessage = RequiredMessage)]
        public DateTime Year { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleMilageMax,
           MinimumLength = VehicleMilageMin,
           ErrorMessage = LengthMessage)]
        public int Mileage { get; set; }
        public int VehicleTypeId { get; set; }

        public IEnumerable<VehicleCategoryServiceModel> VehicleType { get; set; } =
            new List<VehicleCategoryServiceModel>();

        public int? AverageDivingRange { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(5,
           MinimumLength = 2,
           ErrorMessage = LengthMessage)]
        public int Power { get; set; }

        public string Color { get; set; } = string.Empty;
        
        [Required(ErrorMessage = RequiredMessage)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(VehicleDetailsMax,
           MinimumLength = VehicleDetailsMin,
           ErrorMessage = LengthMessage)]
        public string Details { get; set; } = string.Empty;

        public int OwnerId { get; set; }


    }
}
