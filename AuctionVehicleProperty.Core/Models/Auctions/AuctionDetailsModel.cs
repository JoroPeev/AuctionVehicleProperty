using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Models.Auctions
{
    public class AuctionDetailsModel
    {
     
        public int Id { get; set; }

        public DateTime StartingTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal StartingPrice { get; set; }

        public decimal MinimumBidIncrement { get; set; }

        public int? WinnerIdAgent { get; set; }

        public int VehicleId { get; set; }

        public Vehicle Vehicle { get; set; } = null!;

        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }
}
