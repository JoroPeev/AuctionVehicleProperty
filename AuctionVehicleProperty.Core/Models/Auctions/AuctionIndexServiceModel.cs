using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class AuctionIndexServiceModel
    {

        public DateTime StartingTime { get; set; }

        public DateTime EndTime { get; set; }

        public decimal StartingPrice { get; set; }

        public int VehicleId { get; set; }

    }
}
