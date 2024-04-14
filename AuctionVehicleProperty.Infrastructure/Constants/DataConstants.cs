namespace AuctionVehicleProperty.Infrastructure.Constants
{
    public static class DataConstants
    {
        public const int UserFirstNameMinLength = 2;
        public const int UserFirstNameMaxLength = 20;

        public const int UserLastNameMinLength = 2;
        public const int UserLastNameMaxLength = 20;

        public const int AuctionBudIncrementMin = 10;
        public const int AuctionBudIncrementMax = 10_000_000;

        public const int CategoryNameMin = 5;
        public const int CategoryNameMax = 50;

        public const int MakeNameMin = 2;
        public const int MakeNameMax = 40;

        public const int VehicleTitleMin = 10;
        public const int VehicleTitleMax = 100;

        public const int AgentLocationMin = 10;
        public const int AgentLocationMax = 70;


        public const int VehicleMakeMin = 3;
        public const int VehicleMakeMax = 100;

        public const int VehicleModelMin = 3;
        public const int VehicleModelMax = 70;

        public const int VehicleMilageMin = 0;
        public const int VehicleMilageMax = 500_000;

        public const int VehiclePowerMin = 10;
        public const int VehiclePowerMax = 3000;

        public const int VehicleColorMin = 3;
        public const int VehicleColorMax = 50;

        public const int VehicleDetailsMin = 20;
        public const int VehicleDetailsMax = 500;

        public const string DateTimeFormat = "MM/dd/yyyy HH:mm:ss";
    }
}
