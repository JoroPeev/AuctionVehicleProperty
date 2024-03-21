using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static AuctionVehicleProperty.Infrastructure.Constants.DataConstants;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    public class Auction
    {
        [Key]
        [Comment("Auction Identifier")]
        public int Id { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        [Comment("Starting Time")]
        public DateTime StartingTime { get; set; }


        [Required]
        [DataType(DataType.DateTime)]
        [Comment("Ending Time")]
        public DateTime EndTime { get; set; }


        [Required]
        [Column(TypeName = "decimal(12,2)")]
        [Comment("Starting price for auction")]
        public decimal StartingPrice { get; set; }


        [Required]
        [Range(AuctionBudIncrementMin,AuctionBudIncrementMax)]
        [Column(TypeName ="decimal(12,2)")]
        [Comment("Auction Min bid incrementing")]
        public decimal MinimumBidIncrement { get; set; }
        
        
        [Comment("Winner user Identyfier")]
        public string? WinnerIdUser { get; set; }


        [Comment("Winner agent Identyfier")]
        public int? WinnerIdAgent { get; set; }


        [Required]
        [Comment("Vehicle Identyfier")]
        public int VehicleId { get; set; }


        [ForeignKey(nameof(VehicleId))]
        [Comment("Vehicle property")]
        public Vehicle Vehicle { get; set; } = null!;


        [Comment("List of bids")]
        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }
}
