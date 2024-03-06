using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    public class Auction
    {
        [Key]
        [Comment("Auction Identifier")]
        public int Id { get; set; }


        [Required]
        [Comment("Starting Time")]
        public DateTime StartingTime { get; set; }


        [Required]
        [Comment("Ending Time")]
        public DateTime EndTime { get; set; }


        [Required]
        [Comment("Starting price for auction")]
        public decimal StartingPrice { get; set; }


        [Required]
        [Comment("Auction Min bid incrementing")]
        public decimal MinimumBidIncrement { get; set; }
        

        [Comment("Winner Identyfier")]
        public int? WinnerID { get; set; }
        

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
