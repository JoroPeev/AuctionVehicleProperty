using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuctionVehicleProperty.Infrastructure.Data.Models;

namespace AuctionVehicleProperty.Test
{
    [TestFixture]
    public class BidServceTest
    {
        private IRepository repository;
        private IBidService bidService;
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
            bidService = new BidService(repository);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
        [Test]
        public async Task AuctionExistsAsync_Returns_True_If_Auction_Exists()
        {
            var user = new AppUser { UserName = "TESTYTEST" };
            await repository.AddAsync(user);
            await repository.SaveChangesAsync();
            // Arrange
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
            var result = await bidService.AuctionExistsAsync(auctionData.Id);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task AuctionExistsAsync_Returns_False_If_Auction_Does_Not_Exist()
        {
            var nonExistingAuctionId = 13452;

            var result = await bidService.AuctionExistsAsync(nonExistingAuctionId);

            Assert.IsFalse(result);
        }











        [TearDown]
        public void TearDown()
        {
            dbContext.Dispose();
        }
    }

}
