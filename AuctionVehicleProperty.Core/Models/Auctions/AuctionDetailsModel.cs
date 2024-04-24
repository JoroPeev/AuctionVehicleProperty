using AuctionVehicleProperty.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static AuctionVehicleProperty.Core.Constants.MessageConstants;
namespace AuctionVehicleProperty.Core.Models.Auctions
{
    public class AuctionDetailsModel
    {
     
        public int Id { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal StartingPrice { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        public decimal MaxCurrentPrice { get; set; }

        public decimal MinimumBidIncrement { get; set; }

        public int? WinnerIdAgent { get; set; }

        public int CreatorId { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; } = null!;

        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }
}
