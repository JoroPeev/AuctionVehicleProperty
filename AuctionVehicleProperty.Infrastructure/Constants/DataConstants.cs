﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionVehicleProperty.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int AuctionBudIncrementMin = 10;
        public const int AuctionBudIncrementMax = 10000000;

        public const int CategoryNameMin = 5;
        public const int CategoryNameMax = 50;

        public const int MakeNameMin = 2;
        public const int MakeNameMax = 40;

        public const int VehicleTitleMin = 10;
        public const int VehicleTitleMax = 100;

        public const int VehicleMakeMin = 3;
        public const int VehicleMakeMax = 100;

        public const int VehicleModelMin = 5;
        public const int VehicleModelMax = 70;
    }
}
