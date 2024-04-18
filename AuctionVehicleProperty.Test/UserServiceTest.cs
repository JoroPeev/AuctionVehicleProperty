using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Models.User;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AuctionVehicleProperty.Test;

[TestFixture]
public class UserServiceTests
{
    [TestFixture]
    public class UserServiceTest
    {

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
    }
}
