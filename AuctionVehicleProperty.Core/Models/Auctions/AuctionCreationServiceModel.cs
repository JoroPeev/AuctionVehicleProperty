using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AuctionVehicleProperty.Core.Models.Auctions
{
    public class AuctionCreationServiceModel
    {
        public int Id { get; set; }

        [Display(Name = "Starting Time")]
        public DateTime StartingTime { get; set; }

        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        
        [Display(Name = "Starting Price")]
        public decimal StartingPrice { get; set; }

        [Display(Name = "Minimum Bid Increment")]
        public decimal MinimumBidIncrement { get; set; }

        [Display(Name = "Winner")]
        public int? WinnerAgentID { get; set; }

        public string? WinnerUserID { get; set; }

        public int VehicleId { get; set; }

        public ICollection<Bid> Bids { get; set; } = new List<Bid>();

    }
}
