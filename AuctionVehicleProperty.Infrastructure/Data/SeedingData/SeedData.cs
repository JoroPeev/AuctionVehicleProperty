using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AuctionVehicleProperty.Infrastructure.Data.SeedingData
{
    internal class SeedData
    {
        public AppUser AgentUser { get; set; }
        public AppUser GuestUser { get; set; }
        public AppUser SecondGuestUser { get; set; }
        public AppUser AdminUser { get; set; }

        public Agent AdminAgent { get; set; }
        public Agent Agent { get; set; }

        public Bid GuestBid { get; set; }
        public Bid GuestBidFord { get; set; }
        public Bid GuestBidPeugeot { get; set; }

        public Bid SecondGuestBid { get; set; }
        public Auction CarAuction { get; set; }
        public Auction CarAuctionFord { get; set; }
        public Auction CarAuctionPeugeot { get; set; }


        public Category SUVCategory { get; set; }
        public Category CoupeCategory { get; set; }
        public Category SedanCategory { get; set; }
        public Category PickupCategory { get; set; }
        public Category HatchbackCategory { get; set; }
        public Category ConvertibleCategory { get; set; }

        public Vehicle ElectricVehicle { get; set; }
        public Vehicle ElectricVehiclePeugeot { get; set; }
        public Vehicle ElectricVehicleMustang { get; set; }
        

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
            var hasher = new PasswordHasher<AppUser>();

            AgentUser = new AppUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com",
                FirstName = "Agent",
                LastName = "Agentov"
            };

            AgentUser.PasswordHash =
                 hasher.HashPassword(AgentUser, "agent123");

            GuestUser = new AppUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest@mail.com",
                NormalizedEmail = "guest@mail.com",
                FirstName = "Guest",
                LastName = "Guestov"
            };
            AdminUser = new AppUser()
            {
                Id = "e43ce836-997d-4927-ac59-74e8c41bbfd3",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Great",
                LastName = "Admin",
            };
            AdminUser.PasswordHash =
            hasher.HashPassword(AdminUser, "admin123");
            
            GuestUser.PasswordHash =
            hasher.HashPassword(AgentUser, "guest123");

            SecondGuestUser = new AppUser()
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
                Id = 2,
                Email = "yuliusap@pertoys.shop",
                Location = "San Jose 3118 Thunder Road",
                UserId = AgentUser.Id,
                IsAdmin = true,
                
            };
            AdminAgent = new Agent()
            {
                Id = 1,
                Email = "Kolio@gmail.com",
                UserId = AdminUser.Id
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
            DateTime date208 = new DateTime(2023, 8, 23);
            ElectricVehiclePeugeot = new Vehicle()
            {
                Id = 2,
                Title = "Peugeot e-208 50 kWh",
                ImageUrls = "https://ev-database.org/img/auto/Peugeot_e-208_2024/Peugeot_e-208_2024-01.jpg",
                VehicleTypeId = 3,
                Make = "Peugeot",
                Model = "e-208",
                Year = date208,
                Mileage = 0,
                AverageDivingRange = 209,
                Power = 130,
                Color = "Green",
                Location = "679 Grandrose Rd.,Somerset, NJ 08873",
                Details = "This is the electric version of Peugeot’s 208 supermini. It looks very much like the combustion-engined alternative: this isn’t a car for anyone who wants to show off their zero-emission, planet-saving credentials.",
                OwnerId = 1,
                Price = 73000.00M,
            };
            DateTime dateFord = new DateTime(2023, 10, 23);
            ElectricVehicleMustang = new Vehicle()
            {
                Id = 3,
                Title = "Ford Mustang Mach-E ER RWD",
                ImageUrls = "https://ev-database.org/img/auto/Ford_Mustang_Mach-E/Ford_Mustang_Mach-E-01.jpg",
                VehicleTypeId = 1,
                Make = "Ford ",
                Model = " Mustang Mach-E",
                Year = dateFord,
                Mileage = 10000,
                AverageDivingRange = 350,
                Power = 280,
                Color = "Red",
                Location = "44 Willow Street, Piqua, OH 45356",
                Details = "The model shown on this page is the successor of the Ford Mustang Mach-E ER AWD, which was available to order from April 2022 until November 2022. The previous model had 40 km less range, 17% faster acceleration and was 9% less energy efficient.",
                OwnerId = 1,
                Price = 122000.00M,
            };
        }
        private void SeedAuction()
        {
            DateTime date = new DateTime(2024, 04, 28, 16, 30, 00);

            CarAuction = new Auction()
            {
                Id = 1,
                StartingTime = date,
                EndTime = date.AddHours(2),
                StartingPrice = 25000.00M,
                MinimumBidIncrement = 500.00M,
                VehicleId = 1,
                CreatorId = 1
            };
            CarAuctionFord = new Auction()
            {
                Id = 2,
                StartingTime = date,
                EndTime = date.AddHours(2),
                StartingPrice = 122000.00M,
                MinimumBidIncrement = 300.00M,
                VehicleId = 3,
                CreatorId = 1
            };
            CarAuctionPeugeot = new Auction()
            {
                Id = 3,
                StartingTime = date,
                EndTime = date.AddHours(2),
                StartingPrice = 73000.00M,
                MinimumBidIncrement = 200.00M,
                VehicleId = 2,
                CreatorId = 1
            };
        }
        private void SeedBid()
        {
            DateTime date = new DateTime(2024, 04, 25, 12, 30, 00);
            GuestBid = new Bid()
            {
                Id = 1,
                AuctionId = 1,
                AgentId = AdminAgent.Id,
                Amount = 26000.00M,
                BidTime = date.AddMinutes(12),
            };
            SecondGuestBid = new Bid()
            {
                Id = 2,
                AuctionId = 1,
                AgentId = Agent.Id,
                Amount = 27000.00M, 
                BidTime = date.AddMinutes(13),
            };

        }
    }
}
