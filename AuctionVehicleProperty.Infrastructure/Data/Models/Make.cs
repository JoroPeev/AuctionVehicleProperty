using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    [Comment("Vehicle Make")]
    public class Make
    {
        [Key]
        [Comment("Vehicle Make Identifier")]
        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        [Comment("Vehicle Make")]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
