using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.Auctions;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Infrastructure.Data;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuctionVehicleProperty.Test
{
    [TestFixture]
    public class AuctionServiceTest
    {
        private IRepository repository;
        private IAuctionService auctionService;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void Setup()
        {

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<AuctionServiceTest>()
                .Build();

            var connectionString = configuration.GetConnectionString("TestConnection");

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            dbContext = new ApplicationDbContext(contextOptions);
            repository = new Repository(dbContext);
            auctionService = new AuctionService(repository);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
        [Test]
        public async Task AllAuctionsAsync_Returns_All_Auctions_With_AuctionIndexServiceModel()
        {
            var agent = new Agent()
            {
                User = new AppUser { UserName = "TESTY343TEST", },
                Email = "test@t43es.te",
                Location = "testTe43sttest"
            };

            var testVehicle = new Vehicle
            {
                Title = "Te34st",
                Details = "Test det43ils ",
                Location = "Test loca34tion ",
                Mileage = 2004300,
                Power = 23400,
                Make = "TestVe34hicle",
                Model = "Test mo34del ",
                AverageDivingRange = 6400,
                Price = 6004300,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue,
            };


            var agent2 = new Agent()
            {
                User = new AppUser { UserName = "TESTYTEST", },
                Email = "test@tes.te",
                Location = "testTesttest"
            };

            var testVehicle2 = new Vehicle
            {
                Title = "Test",
                Details = "Test details ",
                Location = "Test location ",
                Mileage = 20000,
                Power = 200,
                Make = "TestVehicle",
                Model = "Test model ",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent2,
                VehicleTypeId = 1,
                Year = DateTime.MinValue,
            };

            await repository.AddAsync(testVehicle);
            await repository.AddAsync(testVehicle2);
            await repository.SaveChangesAsync();

            var auction1 = new Auction
            {
                Vehicle = testVehicle,
                EndTime = DateTime.Now.AddDays(1),
                StartingPrice = 5000,
                StartingTime = DateTime.Now,
                MinimumBidIncrement = 100,
                CreatorId = 1
            };

            var auction2 = new Auction
            {
                Vehicle = testVehicle2,
                EndTime = DateTime.Now.AddDays(2),
                StartingPrice = 8000,
                StartingTime = DateTime.Now.AddDays(-1),
                MinimumBidIncrement = 200,
                CreatorId = 2
            };

            await repository.AddAsync(auction1);
            await repository.AddAsync(auction2);
            await repository.SaveChangesAsync();

            var auctions = new List<Auction> { auction1, auction2 };

            // Act
            var result = await auctionService.AllAuctionsAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(repository.All<Auction>().Count()));

            foreach (var auction in auctions)
            {
                var auctionModel = result.FirstOrDefault(a => a.Id == auction.Id);
                Assert.Multiple(() =>
                {
                    Assert.That(auctionModel, Is.Not.Null);
                    Assert.That(auctionModel.EndTime, Is.EqualTo(auction.EndTime));
                    Assert.That(auctionModel.StartingPrice, Is.EqualTo(auction.StartingPrice));
                    Assert.That(auctionModel.StartingTime, Is.EqualTo(auction.StartingTime));
                    Assert.That(auctionModel.MinimumBidIncrement, Is.EqualTo(auction.MinimumBidIncrement));
                    Assert.That(auctionModel.CreatorId, Is.EqualTo(auction.CreatorId));
                });
            }
        }
        [Test]
        public async Task VehicleExistsInOtherAuctionsAsync_Returns_True_When_Vehicle_Exists_In_Other_Auctions()
        {
            var agent = new Agent()
            {
                User = new AppUser { UserName = "TESTYTEST", },
                Email = "test@tes.te",
                Location = "testTesttest"
            };

            var testVehicle = new Vehicle
            {
                Title = "Test",
                Details = "Test details ",
                Location = "Test location ",
                Mileage = 20000,
                Power = 200,
                Make = "TestVehicle",
                Model = "Test model ",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue,
            };

            var auction1 = new Auction
            {
                VehicleId = testVehicle.Id,
                Vehicle = testVehicle,
                EndTime = DateTime.Now.AddDays(1),
                StartingPrice = 5000,
                StartingTime = DateTime.Now,
                MinimumBidIncrement = 100,
                CreatorId = 2
            };

            await repository.AddAsync(testVehicle);
            await repository.AddAsync(auction1);
            await repository.SaveChangesAsync();

            // Act
            var result = await auctionService.VehicleExistsInOtherAuctionsAsync(testVehicle.Id);

            // Assert
            Assert.That(!result, Is.True);
        }

        [Test]
        public async Task VehicleExistsInOtherAuctionsAsync_Returns_False_When_Vehicle_Does_Not_Exist_In_Other_Auctions()
        {
            var agent = new Agent()
            {
                User = new AppUser { UserName = "TESTYTEST", },
                Email = "test@tes.te",
                Location = "testTesttest"
            };

            var testVehicle = new Vehicle
            {
                Title = "Test",
                Details = "Test details ",
                Location = "Test location ",
                Mileage = 20000,
                Power = 200,
                Make = "TestVehicle",
                Model = "Test model ",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue,
            };

            var auction1 = new Auction
            {
                Vehicle = testVehicle,
                EndTime = DateTime.Now.AddDays(1),
                StartingPrice = 5000,
                StartingTime = DateTime.Now,
                MinimumBidIncrement = 100,
                CreatorId = 1,
                VehicleId = 345
            };
            await repository.AddAsync(testVehicle);
            await repository.AddAsync(agent);
            await repository.AddAsync(auction1);
            await repository.SaveChangesAsync();

            // Act
            var result = await auctionService.VehicleExistsInOtherAuctionsAsync(auction1.VehicleId);

            // Assert
            Assert.That(result, Is.False);
        }
        [Test]
        public async Task AuctionValidationCreator_Returns_True_When_User_Is_Creator_Of_Auction()
        {

            var user = new AppUser { UserName = "TESTYTEST", };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();
            var agent = new Agent()
            {
                UserId = user.Id,
                User = user,
                Email = "test@tes.te",
                Location = "testTesttest"
            };
            await repository.AddAsync(agent);
            await repository.SaveChangesAsync();
            var testVehicle = new Vehicle
            {
                Title = "Test",
                Details = "Test details ",
                Location = "Test location ",
                Mileage = 20000,
                Power = 200,
                Make = "TestVehicle",
                Model = "Test model ",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue,
            };
            await repository.AddAsync(testVehicle);
            await repository.SaveChangesAsync();
            var auction1 = new Auction
            {
                Vehicle = testVehicle,
                VehicleId = testVehicle.Id,
                EndTime = DateTime.Now.AddDays(1),
                StartingPrice = 5000,
                StartingTime = DateTime.Now,
                MinimumBidIncrement = 100,
                CreatorId = agent.Id
            };
            await repository.AddAsync(auction1);
            await repository.SaveChangesAsync();


            // Act
            var result = await auctionService.AuctionValidationCreator(auction1.Id, user.Id);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public async Task AuctionExistAsync_Returns_True_When_Auction_Exists()
        {
            var user = new AppUser { UserName = "TESTYTEST", };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();
            var agent = new Agent()
            {
                UserId = user.Id,
                User = user,
                Email = "test@tes.te",
                Location = "testTesttest"
            };
            await repository.AddAsync(agent);
            await repository.SaveChangesAsync();
            var testVehicle = new Vehicle
            {
                Title = "Test",
                Details = "Test details ",
                Location = "Test location ",
                Mileage = 20000,
                Power = 200,
                Make = "TestVehicle",
                Model = "Test model ",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue,
            };
            await repository.AddAsync(testVehicle);
            await repository.SaveChangesAsync();
            var auction1 = new Auction
            {
                Vehicle = testVehicle,
                VehicleId = testVehicle.Id,
                EndTime = DateTime.Now.AddDays(1),
                StartingPrice = 5000,
                StartingTime = DateTime.Now,
                MinimumBidIncrement = 100,
                CreatorId = agent.Id
            };
            await repository.AddAsync(auction1);
            await repository.SaveChangesAsync();


            var result = await auctionService.AuctionExistAsync(auction1.Id);

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task AuctionExistAsync_Returns_False_When_Auction_Does_Not_Exist()
        {
            var auctionId = 3456;

            var result = await auctionService.AuctionExistAsync(auctionId);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task CreateAsync_Adds_New_Auction_To_Repository()
        {
            // Arrange
            // Create a new user
            var user = new AppUser { UserName = "TESTYTEST" };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            // Create an agent associated with the user
            var agent = new Agent
            {
                User = user,
                Email = "test@tes.te",
                Location = "testTesttest"
            };
            await repository.AddAsync(agent);
            await repository.SaveChangesAsync();

            // Create a vehicle associated with the agent
            var vehicle = new Vehicle
            {
                Title = "Test Vehicle",
                Details = "Test details",
                Location = "Test location",
                Mileage = 20000,
                Power = 200,
                Make = "Test Make",
                Model = "Test Model",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue
            };
            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();

            var auctionData = new Auction
            {
                StartingPrice = 12344,
                EndTime = DateTime.MaxValue,
                StartingTime = DateTime.MinValue,
                MinimumBidIncrement = 12345,
                VehicleId = vehicle.Id,
                CreatorId = agent.Id
            };

            // Act
            await repository.AddAsync(auctionData);
            await repository.SaveChangesAsync();
            // Assert
            var createdAuction = await repository.GetByIdAsync<Auction>(auctionData.Id);
            Assert.That(createdAuction, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createdAuction.StartingPrice, Is.EqualTo(auctionData.StartingPrice));
                Assert.That(createdAuction.EndTime, Is.EqualTo(auctionData.EndTime));
                Assert.That(createdAuction.StartingTime, Is.EqualTo(auctionData.StartingTime));
                Assert.That(createdAuction.MinimumBidIncrement, Is.EqualTo(auctionData.MinimumBidIncrement));
                Assert.That(createdAuction.VehicleId, Is.EqualTo(auctionData.VehicleId));
                Assert.That(createdAuction.CreatorId, Is.EqualTo(auctionData.CreatorId));
            });
        }

        [Test]
        public async Task CreateAsync_Adds_New_Auction()
        {
            // Arrange
            var auctionData = new AuctionCreationServiceModel
            {
                StartingPrice = 5000,
                EndTime = DateTime.Now.AddDays(1),
                MinimumBidIncrement = 100,
                VehicleId = 1,
                CreatorId = 123
            };

            // Act
            await auctionService.CreateAsync(auctionData);

            // Assert
            var createdAuction = await repository.AllReadOnly<Auction>()
                .FirstOrDefaultAsync(a => a.StartingPrice == auctionData.StartingPrice
                    && a.EndTime == auctionData.EndTime
                    && a.MinimumBidIncrement == auctionData.MinimumBidIncrement
                    && a.VehicleId == auctionData.VehicleId
                    && a.CreatorId == auctionData.CreatorId);

            Assert.That(createdAuction, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createdAuction.StartingPrice, Is.EqualTo(auctionData.StartingPrice));
                Assert.That(createdAuction.EndTime, Is.EqualTo(auctionData.EndTime));
                Assert.AreEqual(DateTime.Now.Date, createdAuction.StartingTime.Date);
                Assert.That(createdAuction.MinimumBidIncrement, Is.EqualTo(auctionData.MinimumBidIncrement));
                Assert.That(createdAuction.VehicleId, Is.EqualTo(auctionData.VehicleId));
                Assert.That(createdAuction.CreatorId, Is.EqualTo(auctionData.CreatorId));
            });
        }

        [Test]
        public async Task GetAuctionBidsAsync_Returns_Bids_For_Auction()
        {
            var user = new AppUser { UserName = "TESTYTEST" };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var agent = new Agent
            {
                User = user,
                Email = "test@tes.te",
                Location = "testTesttest"
            };
            await repository.AddAsync(agent);
            await repository.SaveChangesAsync();
            var vehicle = new Vehicle
            {
                Title = "Test Vehicle",
                Details = "Test details",
                Location = "Test location",
                Mileage = 20000,
                Power = 200,
                Make = "Test Make",
                Model = "Test Model",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue
            };
            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();
            var auctionData = new Auction
            {
                StartingPrice = 12344,
                EndTime = DateTime.MaxValue,
                StartingTime = DateTime.MinValue,
                MinimumBidIncrement = 12345,
                VehicleId = vehicle.Id,
                CreatorId = agent.Id
            };

            await repository.AddAsync(auctionData);
            await repository.SaveChangesAsync();



            var bid = new Bid()
            {
                BidTime = DateTime.MaxValue,
                Amount = 76234598,
                AuctionId = auctionData.Id,
                AgentId = agent.Id,


            };
            await repository.AddAsync(bid);
            await repository.SaveChangesAsync();

            // Act
            var result = await auctionService.GetAuctionBidsAsync(auctionData.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(1));
            Assert.That(result.Any(b => b.Id == bid.Id && b.Amount == bid.Amount && b.AuctionId == bid.AuctionId), Is.True);

        }
        [Test]
        public async Task GetAuctionDetailsAsync_Returns_Auction_Details_With_Vehicle()
        {
            var user = new AppUser { UserName = "TESTYTEST" };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var agent = new Agent
            {
                User = user,
                Email = "test@tes.te",
                Location = "testTesttest"
            };
            await repository.AddAsync(agent);
            await repository.SaveChangesAsync();
            var vehicle = new Vehicle
            {
                Title = "Test Vehicle",
                Details = "Test details",
                Location = "Test location",
                Mileage = 20000,
                Power = 200,
                Make = "Test Make",
                Model = "Test Model",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue
            };
            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();
            var auctionData = new Auction
            {
                StartingPrice = 12344,
                EndTime = DateTime.MaxValue,
                StartingTime = DateTime.MinValue,
                MinimumBidIncrement = 12345,
                VehicleId = vehicle.Id,
                CreatorId = agent.Id
            };

            await repository.AddAsync(auctionData);
            await repository.SaveChangesAsync();

            // Act
            var result = await auctionService.GetAuctionDetailsAsync(auctionData.Id);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.EndTime, Is.EqualTo(auctionData.EndTime));
                Assert.That(result.StartingTime, Is.EqualTo(auctionData.StartingTime));
                Assert.That(result.MinimumBidIncrement, Is.EqualTo(auctionData.MinimumBidIncrement));
                Assert.That(result.StartingPrice, Is.EqualTo(auctionData.StartingPrice));
                Assert.That(result.VehicleId, Is.EqualTo(auctionData.VehicleId));
                Assert.That(result.CreatorId, Is.EqualTo(auctionData.CreatorId));
            });
            Assert.That(result.Vehicle, Is.Not.Null);
        }

        [Test]
        public async Task DeleteAuctionAsync_Removes_Auction_From_Repository()
        {
            var user = new AppUser { UserName = "TESTYTEST" };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var agent = new Agent
            {
                User = user,
                Email = "test@tes.te",
                Location = "testTesttest"
            };
            await repository.AddAsync(agent);
            await repository.SaveChangesAsync();

            var vehicle = new Vehicle
            {
                Title = "Test Vehicle",
                Details = "Test details",
                Location = "Test location",
                Mileage = 20000,
                Power = 200,
                Make = "Test Make",
                Model = "Test Model",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue
            };
            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();

            var auctionData = new Auction
            {
                StartingPrice = 12344,
                EndTime = DateTime.MaxValue,
                StartingTime = DateTime.MinValue,
                MinimumBidIncrement = 12345,
                VehicleId = vehicle.Id,
                CreatorId = agent.Id
            };
            await repository.AddAsync(auctionData);
            await repository.SaveChangesAsync();


            await auctionService.DeleteAuctionAsync(auctionData.Id);

            var deletedAuction = await repository.GetByIdAsync<Auction>(auctionData.Id);
            Assert.That(deletedAuction, Is.Null);
        }
        [Test]
        public async Task UpdateAuctionAsync_Updates_Auction_In_Repository()
        {
            // Arrange
            var user = new AppUser { UserName = "TESTYTEST" };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            var agent = new Agent
            {
                User = user,
                Email = "test@tes.te",
                Location = "testTesttest"
            };
            await repository.AddAsync(agent);
            await repository.SaveChangesAsync();

            var vehicle = new Vehicle
            {
                Title = "Test Vehicle",
                Details = "Test details",
                Location = "Test location",
                Mileage = 20000,
                Power = 200,
                Make = "Test Make",
                Model = "Test Model",
                AverageDivingRange = 600,
                Price = 60000,
                Owner = agent,
                VehicleTypeId = 1,
                Year = DateTime.MinValue
            };
            await repository.AddAsync(vehicle);
            await repository.SaveChangesAsync();

            var auctionData = new Auction
            {
                StartingPrice = 12344,
                EndTime = DateTime.MaxValue,
                StartingTime = DateTime.MinValue,
                MinimumBidIncrement = 12345,
                VehicleId = vehicle.Id,
                CreatorId = agent.Id
            };
            await repository.AddAsync(auctionData);
            await repository.SaveChangesAsync();

            // Act
            var updatedAuction = new AuctionCreationServiceModel
            {
                Id = auctionData.Id,
                CreatorId = agent.Id,
                StartingPrice = 54321,
                StartingTime = DateTime.UtcNow,
                MinimumBidIncrement = 10000,
                VehicleId = vehicle.Id,
                EndTime = DateTime.UtcNow.AddDays(7),
                Bids = new List<Bid>()
            };
            await auctionService.UpdateAuctionAsync(updatedAuction);

            // Assert
            var updatedAuctionFromRepo = await repository.GetByIdAsync<Auction>(auctionData.Id);
            Assert.IsNotNull(updatedAuctionFromRepo);
            Assert.AreEqual(updatedAuction.StartingPrice, updatedAuctionFromRepo.StartingPrice);
            Assert.AreEqual(updatedAuction.StartingTime, updatedAuctionFromRepo.StartingTime);
            Assert.AreEqual(updatedAuction.MinimumBidIncrement, updatedAuctionFromRepo.MinimumBidIncrement);
            Assert.AreEqual(updatedAuction.VehicleId, updatedAuctionFromRepo.VehicleId);
            Assert.AreEqual(updatedAuction.EndTime, updatedAuctionFromRepo.EndTime);
            // Add more assertions for other properties if needed
        }


        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }
}
