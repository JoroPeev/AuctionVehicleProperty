using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AuctionVehicleProperty.Infrastructure.Data.Models
{
    public class Bid
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Comment("Auction identifier")]
        public int AuctionId { get; set; }


        [ForeignKey(nameof(AuctionId))]
        [Comment("Bid Auction property")]
        public Auction Auction { get; set; } = null!;


        [Required]
        [Comment("Agent Identifier")]
        public int AgentId { get; set; }


        [ForeignKey(nameof(AgentId))]
        [Comment("User Bidding")]
        public Agent Agent { get; set; } = null!;


        [Column(TypeName = "decimal(12,2)")]
        [Comment("Bid Amount")]
        public decimal Amount { get; set; }

        
        [Comment("Bid Date and Time")]
        public DateTime BidTime { get; set; }


    }
}