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
using NUnit.Framework.Internal;


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
    [Test]
    public async Task GetVehicleByOwnerIdAsync_Returns_Correct_Vehicle()
    {
        // Arrange
        int existingVehicleId = 5;
        var testVehicle = new Vehicle
        {
            Id = existingVehicleId,
            Details = "Test details",
            ImageUrls = "Test image URL",
            Location = "Test location",
            Make = "Test make",
            Mileage = 10000,
            Power = 150,
            Model = "Test model",
            AverageDivingRange = 500,
            OwnerId = 123, 
            Price = 50000,
            Title = "Test title",
            VehicleTypeId = 456, 
            Year = DateTime.MinValue
        };

        var testVehicleType = new Category { Id = testVehicle.VehicleTypeId, Name = "Test Vehicle Type" };

        await repository.AddAsync(testVehicle);

        await repository.AddAsync(testVehicleType);

        await repository.SaveChangesAsync();

        var vehicleService = new VehicleService(repository);

 
        var result = await vehicleService.GetVehicleByOwnerIdAsync(existingVehicleId);


        Assert.IsNotNull(result);
        Assert.That(result.Id, Is.EqualTo(existingVehicleId));
        Assert.That(result.Details, Is.EqualTo("Test details"));
        Assert.That(result.ImageUrl, Is.EqualTo("Test image URL"));
        Assert.That(result.Location, Is.EqualTo("Test location"));
        Assert.That(result.Make, Is.EqualTo("Test make"));
        Assert.That(result.Mileage, Is.EqualTo(10000));
        Assert.That(result.Power, Is.EqualTo(150));
        Assert.That(result.Model, Is.EqualTo("Test model"));
        Assert.That(result.AverageDivingRange, Is.EqualTo(500));
        Assert.That(result.OwnerId, Is.EqualTo(123));
        Assert.That(result.Price, Is.EqualTo(50000));
        Assert.That(result.Title, Is.EqualTo("Test title"));
        Assert.That(result.VehicleTypeId, Is.EqualTo(testVehicleType.Id));
        Assert.That(result.Year, Is.EqualTo(DateTime.MinValue));
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Dispose();
    }
}

