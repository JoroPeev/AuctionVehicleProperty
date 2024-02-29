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

        [Required]
        [Comment("Used or brand new")]
        public Condition Condition { get; set; } = null!;

        [Required]
        [Comment("Vehicle Type")]
        public VehicleType VehicleType { get; set; } = null!;

        [Required]
        [StringLength(50)]
        [Comment("Vehicle Make")]
        public string Make { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Comment("Vehicle Model")]
        public string Model { get; set; } = string.Empty;


        [Comment("Vehicle year of production")]
        public ProductionYear Year { get; set; }

        [Comment("Vehicle Milage in kilometers")]
        public int Mileage { get; set; }

        [Required]
        [Comment("Vehicle Power in horse power or in Kw")]
        public int Power { get; set; }

        [Required]
        [Comment("Vehicle Collor")]
        public string Color { get; set; } = string.Empty;

        [Required]
        [Comment("Vehicle Price")]
        public decimal Price { get; set; }

        [Required]
        [Comment("Buisness seller or Individual seller or Dealers")]
        public string SellerId { get; set; } = string.Empty;

        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; } = null!;


    }
}
