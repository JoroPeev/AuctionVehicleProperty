using AuctionVehicleProperty.Infrastructure.Data.Models;
using System.ComponentModel.DataAnnotations;
using static AuctionVehicleProperty.Core.Constants.MessageConstants;
using static AuctionVehicleProperty.Infrastructure.Constants.DataConstants;
namespace AuctionVehicleProperty.Core.Models.Auctions;

public class AuctionCreationServiceModel
{
    public int Id { get; set; }


    [Required(ErrorMessage = RequiredMessage)]
    [Display(Name = "Starting Time")]
    public DateTime StartingTime { get; set; }


    [Required(ErrorMessage = RequiredMessage)]
    [Display(Name = "End Time")]
    public DateTime EndTime { get; set; }


    [Required(ErrorMessage = RequiredMessage)]
    [Display(Name = "Starting Price")]
    public decimal StartingPrice { get; set; }


    [Required(ErrorMessage = RequiredMessage)]
    [Display(Name = "Minimum Bid Increment")]
    public decimal MinimumBidIncrement { get; set; }

    [Display(Name = "Winner")]
    public int? WinnerAgentID { get; set; }

    public string? WinnerUserID { get; set; }

    public int CreatorId { get; set; }

    public int VehicleId { get; set; }

    public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    public ICollection<Bid> Bids { get; set; } = new List<Bid>();

}
