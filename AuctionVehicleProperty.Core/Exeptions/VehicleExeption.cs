using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Exeptions
{
    public class VehicleExeption : Exception
    {

        public VehicleExeption(){}

        public VehicleExeption(string message)
           : base(message) { }

    }
}
