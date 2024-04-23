using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Models.Bids
{
    public class PlacingBidAgent
    {
        public int UserId { get; set; }

        public decimal Amount { get; set; }

        public DateTime BidTime { get; set; }

        public int AuctionId { get; set; }

    }
}
