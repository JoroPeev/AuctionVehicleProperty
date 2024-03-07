using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static AuctionVehicleProperty.Infrastructure.Constants.DataConstants;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    [Comment("Vehicle Make")]
    public class Make
    {
        [Key]
        [Comment("Vehicle Make Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(MakeNameMax)]
        [Comment("Vehicle Make")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
