using AuctionVehicleProperty.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Models.Agents
{
    public class AgentUpdateServiceModel
    {
        public string Email { get; set; } = String.Empty;
        public string Location { get; set; } = string.Empty;

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
