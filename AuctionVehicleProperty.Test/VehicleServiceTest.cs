using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;
using AuctionVehicleProperty.Infrastructure.Data;
using AuctionVehicleProperty.Core.Contracts;
using Microsoft.Extensions.Configuration;


namespace AuctionVehicleProperty.Test;

[TestFixture]
public class VehicleServiceTest
{

    private IRepository repository;
    private IVehicleService vehicleService;
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
        vehicleService = new VehicleService(repository);

        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }
    [Test]
    public async Task AddVehicleAsync_WhenCalled_ReturnsVehicleId()
    {
        var date = DateTime.Now;
        // Arrange
        var vehicle = new VehicleCreationServiceModel
        {
            Title = "Test Vehicle",
            ImageUrl = "test_image_url",
            VehicleTypeId = 1,
            Make = "Test Make",
            Model = "Test Model",
            Year = date,
            Mileage = 10000,
            AverageDivingRange = 400,
            Power = 200,
            Price = 30000,
            Location = "Test Location",
            Details = "Test Details",
            Color = "Test Color",
        };

        var agentId = 1;


        var result = await vehicleService.AddVehicleAsync(vehicle, agentId);


        Assert.That(result, Is.Not.EqualTo(0));
    }
    [Test]
    public async Task AllAsync_Returns_All_Vehicles_When_No_Filters_Applied()
    {

        var result = await vehicleService.AllAsync();

        Assert.That(result.Vehicles.Count(), Is.EqualTo(result.TotalVehiclesCount));
    }

    [Test]
    public async Task AllAsync_Returns_Correct_Number_Of_Vehicles_When_Filtered_By_Category()
    {
        string category = "SUV";

        var result = await vehicleService.AllAsync(category: category);

        Assert.IsTrue(result.Vehicles.All(v => v.VehicleType == category));
    }
    [Test]
    public async Task CategoryExistsAsync_Returns_True_When_Category_Exists()
    {
        int existingCategoryId = 1;
        var existingCategory = new Category { Id = existingCategoryId};
        await dbContext.Categories.AddAsync(existingCategory);

        var result = await vehicleService.CategoryExistsAsync(existingCategoryId);

        Assert.IsTrue(result);
    }

    [Test]
    public async Task CategoryExistsAsync_Returns_False_When_Category_Does_Not_Exist()
    {
        int nonExistingCategoryId = 999;

        var result = await vehicleService.CategoryExistsAsync(nonExistingCategoryId);

        Assert.IsFalse(result);
    }
    




    [TearDown]
    public void TearDown()
    {
        dbContext.Dispose();
    }
}

