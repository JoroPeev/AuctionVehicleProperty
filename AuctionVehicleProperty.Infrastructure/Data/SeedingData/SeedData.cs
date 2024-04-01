using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AuctionVehicleProperty.Infrastructure.Data.SeedingData
{
    internal class SeedData
    {
        public IdentityUser AgentUser { get; set; }
        public IdentityUser GuestUser { get; set; }
        public IdentityUser SecondGuestUser { get; set; }

        public Agent Agent { get; set; }

        public Bid GuestBid { get; set; }
        public Bid SecondGuestBid { get; set; }

        public Auction CarAuction { get; set; }

        public Category SUVCategory { get; set; }
        public Category CoupeCategory { get; set; }
        public Category SedanCategory { get; set; }
        public Category PickupCategory { get; set; }
        public Category HatchbackCategory { get; set; }
        public Category ConvertibleCategory { get; set; }

        public Vehicle ElectricVehicle { get; set; }
        public Vehicle HybridVehicle { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAgent();
            SeedCategories();
            SeedVehicles();
            SeedAuction();
            SeedBid();
        }
        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AgentUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            AgentUser.PasswordHash =
                 hasher.HashPassword(AgentUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AgentUser, "guest123");

            SecondGuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591s",
                UserName = "Secondguest@mail.com",
                NormalizedUserName = "Secondguest@mail.com",
                Email = "Secondguest@mail.com",
                NormalizedEmail = "Secondguest@mail.com"
            };

            GuestUser.PasswordHash =
            hasher.HashPassword(AgentUser, "Secondguest123");
        }
        private void SeedAgent()
        {
            Agent = new Agent()
            {
                Id = 1,
                Email = "yuliusap@pertoys.shop",
                Location = "San Jose 3118 Thunder Road",
                UserId = AgentUser.Id
            };
        }
        private void SeedCategories()
        {
            SUVCategory = new Category()
            {
                Id = 1,
                Name = "Sport utility vehicle (SUV)"
            };

            CoupeCategory = new Category()
            {
                Id = 2,
                Name = "Coupe"
            };

            HatchbackCategory = new Category()
            {
                Id = 3,
                Name = "Hatchback"
            };

            ConvertibleCategory = new Category()
            {
                Id = 4,
                Name = "Convertible"
            };

            PickupCategory = new Category()
            {
                Id = 5,
                Name = "Pickup Truck"
            };

            SedanCategory = new Category()
            {
                Id = 6,
                Name = "Sedan"
            };
        }
        private void SeedVehicles()
        {
            DateTime date = new DateTime(2024,12,23);

            ElectricVehicle = new Vehicle()
            {
                Id = 1,
                Title = "2024 Renault 5 E-Tech 52 kWh (150 hp) Electric",
                ImageUrls = "https://www.auto-data.net/images/f46/Renault-5-E-Tech_1.jpg",
                VehicleTypeId = 3,
                Make = "Renault",
                Model = "5 E-Tech",
                Year = date,
                Mileage = 0,
                AverageDivingRange = 330,
                Power = 150,
                Color = "Yellow",
                Location = "3118 Thunder Road, San Jose, CA, 95134",
                Details = "Fuel Type: Electricity," +
                " Acceleration: 0 - 100 km/h: 8 sec," +
                " Maximum speed: 150 km/h (93.21 mph)," +
                " Weight-to-power ratio: 9.7 kg/Hp, 103.4 Hp/tonne," +
                " Weight-to-torque ratio: 5.9 kg/Nm, 169 Nm",
                OwnerId = 1,
                Price = 32000.00M,
            };
            HybridVehicle = new Vehicle()
            {
                Id = 2,
                Title = "2024 Ford Kuga III ST-Line 2.5 (243 кс) Plug-in Hybrid CVT",
                ImageUrls = "https://autobild.bg/wp-content/uploads/2024/01/image-125-720x404.png",
                VehicleTypeId = 1,
                Make = "Ford",
                Model = "Kuga III facelift",
                Year = date,
                Mileage = 0,
                Power = 243,
                Color = "Blue",
                Location = "3189 Duke Lane, Newark, NJ, 07102",
                Details = "Modification (Engine): ST-Line 2.5 (243 Hp) Plug-in Hybrid CVT," +
                " Powertrain Architecture: PHEV (Plug-in Hybrid Electric Vehicle)," +
                " Combined fuel consumption: 0.9-1.2 l/100 km," +
                " CO2 emissions: 20-28 g/km," +
                " Fuel Type: Petrol / electricity," +
                " Acceleration 0 - 100 km/h: 7.3 sec," +
                " Acceleration 0 - 62 mph: 7.3 sec," +
                " Maximum speed: 200 km/h (124.27 mph)," +
                " Emission standard: Euro 6d.",
                OwnerId = 1,
                Price = 37610.00M,
            };
        }
        private void SeedAuction()
        {
            DateTime date = new DateTime(2024, 04, 25, 12, 30, 00);

            CarAuction = new Auction()
            {
                Id = 1,
                StartingTime = date,
                EndTime = date.AddHours(2),
                StartingPrice = 25000.00M,
                MinimumBidIncrement = 500.00M,
                VehicleId = 1,
            };
        }
        private void SeedBid()
        {
            DateTime date = new DateTime(2024, 04, 25, 12, 30, 00);
            GuestBid = new Bid()
            {
                Id = 1,
                AuctionId = 1,
                CustomerId = GuestUser.Id,
                Amount = 26000.00M,
                BidTime = date.AddMinutes(12),
            };
            SecondGuestBid = new Bid()
            {
                Id = 2,
                AuctionId = 1,
                CustomerId = SecondGuestUser.Id,
                Amount = 27000.00M,
                BidTime = date.AddMinutes(13),
            };

        }
    }
}
