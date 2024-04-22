using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.User;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Infrastructure.Data;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;

namespace AuctionVehicleProperty.Test;

[TestFixture]
public class UserServiceTests
{
    [TestFixture]
    public class UserServiceTest
    {
        private IRepository repository;
        private IUserService userService;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void Setup()
        {

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<VehicleServiceTest>()
                .Build();

            var connectionString = configuration.GetConnectionString("TestConnection");

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            dbContext = new ApplicationDbContext(contextOptions);
            repository = new Repository(dbContext);
            userService = new UserService(repository);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
        [Test]
        public async Task UserFullNameAsync_ReturnsFullName()
        {
            var mockRepository = new Mock<IRepository>();
            var userId = "1";
            var user = new AppUser { Id = userId, FirstName = "John", LastName = "Doe" };
            mockRepository.Setup(repo => repo.GetByIdAsync<AppUser>(userId)).ReturnsAsync(user);

            var userService = new UserService(mockRepository.Object);

            var expectedFullName = "John Doe";

            var result = await userService.UserFullNameAsync(userId);

            Assert.That(result, Is.EqualTo(expectedFullName));
        }

        [Test]
        public async Task UserFullNameAsync_ReturnsEmptyStringWhenUserNotFound()
        {
            var mockRepository = new Mock<IRepository>();
            var userId = "1";
            mockRepository.Setup(repo => repo.GetByIdAsync<AppUser>(userId)).ReturnsAsync((AppUser)null);

            var userService = new UserService(mockRepository.Object);


            var expectedFullName = string.Empty;
            var result = await userService.UserFullNameAsync(userId);

            Assert.That(result, Is.EqualTo(expectedFullName));
        }

        [Test]
        public async Task AllAsync_Returns_All_Users_With_UserServiceModel()
        {

            var user1 = new AppUser { Email = "user1@example.com", FirstName = "John", LastName = "Doe" };
            var user2 = new AppUser { Email = "user2@example.com", FirstName = "Jane", LastName = "Smith", };
    
            await repository.AddAsync(user1);
            await repository.AddAsync(user2);
            await repository.SaveChangesAsync();

            List<AppUser> users = new List<AppUser> {user1, user2};


            var result = await userService.AllAsync();

            Assert.NotNull(result);
            Assert.That(result.Count(), Is.EqualTo(repository.All<AppUser>().Count()));

            foreach (var user in users)
            {
                var userModel = result.FirstOrDefault(u => u.Email == user.Email);
                Assert.That(userModel, Is.Not.Null);
                Assert.That(userModel.FullName, Is.EqualTo($"{user.FirstName} {user.LastName}"));
                Assert.That(userModel.IsAgent, Is.EqualTo(user.Agent != null));
            }
        }
    }
}
