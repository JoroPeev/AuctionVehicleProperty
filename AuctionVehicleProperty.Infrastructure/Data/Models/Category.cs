using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static AuctionVehicleProperty.Infrastructure.Constants.DataConstants;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        [Comment("VehicleType Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMax)]
        [Comment("VehicleType Name")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}