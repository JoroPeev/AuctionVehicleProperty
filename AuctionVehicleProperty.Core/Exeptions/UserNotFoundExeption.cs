using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Core.Exeptions
{
    public class UserNotFoundExeption:Exception
    {
        public UserNotFoundExeption(){}

        public UserNotFoundExeption(string message) : base(message) { }


    }
}
