using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    public class Bid
    {
        [Key]
        public int BidID { get; set; }

        [Required]
        [Comment("Auction identifier")]
        public int AuctionId { get; set; }


        [ForeignKey(nameof(AuctionId))]
        [Comment("Bid Auction property")]
        public Auction Auction { get; set; } = null!;


        [Required]
        [Comment("Customer Identifier")]
        public string CustomerID { get; set; } = string.Empty;


        [ForeignKey(nameof(CustomerID))]
        [Comment("User Bidding")]
        public IdentityUser User { get; set; } = null!;


        [Column(TypeName = "decimal(12,2)")]
        [Comment("Bid Amount")]
        public decimal Amount { get; set; }

        
        [Comment("Bid Date and Time")]
        public DateTime BidTime { get; set; }


        public List<IdentityUser> Users { get; set; } = new List<IdentityUser>();

    }
}