using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    [Comment("Vehicle to sell or buy in auction")]
    public class Vehicle
    {
        [Key]
        [Comment("Vehicle Identifier")]
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        [Comment("Vehicle Title")]
        public string Title { get; set; } = string.Empty;


        [Comment("Vehicle Image")]
        public string ImageUrl { get; set; } = string.Empty;


        [Required]
        [Comment("VehicleType Identyfier")]
        public int VehicleTypeId { get; set; }


        [Required]
        [Comment("Vehicle Type")]
        [ForeignKey(nameof(VehicleTypeId))]
        public Category VehicleType { get; set; } = null!;


        [Required]
        [MaxLength(100)]
        [Comment("Vehicle Make")]
        public string Make { get; set; } = null!;


        [Required]
        [StringLength(70)]
        [Comment("Vehicle Model")]
        public string Model { get; set; } = string.Empty;


        [Required]
        [MaxLength(10)]
        [Comment("Vehicle year of production")]
        public string Year { get; set; } = string.Empty;


        [Required]
        [Comment("Vehicle Milage in kilometers")]
        public int Mileage { get; set; }


        [Required]
        [Comment("Vehicle Power in horse power or in Kw")]
        public int Power { get; set; }


        [Required]
        [MaxLength(50)]
        [Comment("Vehicle Collor")]
        public string Color { get; set; } = string.Empty;


        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Comment("Vehicle Price")]
        public decimal Price { get; set; }

        
        [Required]
        [Comment("Location of the Vehicle")]
        public string Location { get; set; } = string.Empty;


        [Required]
        [Comment("Vehicle Details")]
        [MaxLength(500)]
        public string Details { get; set; } = string.Empty;

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;



    }
}
