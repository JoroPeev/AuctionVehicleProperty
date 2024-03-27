using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AuctionVehicleProperty.Infrastructure.Constants.DataConstants;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Agent
    {
        [Key]
        [Comment("Agent identifier")]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [Comment("Agent's Email")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(AgentLocationMax)]
        [Comment("Agent's Location")]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Comment("User Identifier")]
        public string UserId { get; set; } = string.Empty;


        [Comment("Identity User Property")]
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;


        [Comment("Agent Collection of Vehicles")]
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();



    }
}
