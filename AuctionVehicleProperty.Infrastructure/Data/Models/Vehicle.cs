using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AuctionVehicleProperty.Infrastructure.Constants.DataConstants;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    [Comment("Vehicle to sell or buy in auction")]
    public class Vehicle
    {
        [Key]
        [Comment("Vehicle Identifier")]
        public int Id { get; set; }


        [Required]
        [StringLength(VehicleTitleMax)]
        [Comment("Vehicle Title")]
        public string Title { get; set; } = string.Empty;


        [Comment("Vehicle Images")]
        public string ImageUrls { get; set; } = String.Empty;


        [Required]
        [Comment("VehicleType Identyfier")]
        public int VehicleTypeId { get; set; }


        [Required]
        [Comment("Vehicle Type")]
        [ForeignKey(nameof(VehicleTypeId))]
        public Category VehicleType { get; set; } = null!;


        [Required]
        [MaxLength(VehicleMakeMax)]
        [Comment("Vehicle Make")]
        public string Make { get; set; } = null!;


        [Required]
        [StringLength(VehicleModelMax)]
        [Comment("Vehicle Model")]
        public string Model { get; set; } = string.Empty;


        [Required]
        [Comment("Vehicle year of production")]
        public DateTime Year { get; set; }


        [Required]
        [Range(VehicleMilageMin, VehicleMilageMax)]
        [Comment("Vehicle Milage in kilometers")]
        public int Mileage { get; set; }

        [Comment("If is electric range of driving in kilometers")]
        public int? AverageDivingRange { get; set; }


        [Required]
        [Range(VehiclePowerMin, VehiclePowerMax)]
        [Comment("Vehicle Power in horse power or in Kw")]
        public int Power { get; set; }


        [Required]
        [MaxLength(VehicleColorMax)]
        [Comment("Vehicle Collor")]
        public string Color { get; set; } = string.Empty;


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Comment("Vehicle Price")]
        public decimal Price { get; set; }

        
        [Required]
        [Comment("Location of the Vehicle")]
        public string Location { get; set; } = string.Empty;


        [Required]
        [Comment("Vehicle Details")]
        [MaxLength(VehicleDetailsMax)]
        public string Details { get; set; } = string.Empty;

        [Required]
        public int OwnerId { get; set; }

        [Required]
        [ForeignKey(nameof(OwnerId))]
        public Agent Owner { get; set; } = null!;



    }
}
