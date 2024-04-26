using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Enumerations;
using AuctionVehicleProperty.Core.Models.Vehicles;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Infrastructure.Data;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            Id = 1,
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
    public async Task AllAsync_Returns_Correct_Vehicles_When_Filtering_By_Category()
    {
        // Arrange
        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"
        };

        var testVehicle = new Vehicle
        {
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
        var testVehicle2 = new Vehicle
        {
            Details = "Test 2",
            Location = "Test location 2",
            Mileage = 20000,
            Power = 200,
            Make = "TestVehicle2",
            Model = "Test model 2",
            AverageDivingRange = 600,
            Price = 60000,
            Owner = agent,
            VehicleTypeId = 2,
            Year = DateTime.MinValue,
        };
        await repository.AddAsync(testVehicle);
        await repository.AddAsync(testVehicle2);
        await repository.SaveChangesAsync();

        var result = await vehicleService.AllAsync("Coupe");

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Vehicles.Count(), Is.EqualTo(1));
            Assert.That(result.TotalVehiclesCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task AllAsync_Returns_Vehicles_Sorted_By_Price()
    {
        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"
        };

        var SUVCategory = new Category()
        {
            Name = "Sport utility vehicle (SUV)"
        };
        var coupe = new Category()
        {
            Name = "Coupe"
        };

        var testVehicle = new Vehicle
        {
            Details = "Test details ",
            Location = "Test location ",
            Mileage = 123,
            Power = 200,
            Make = "TestVehicle",
            Model = "Test model ",
            AverageDivingRange = 600,
            Price = 123,
            Owner = agent,
            VehicleTypeId = 1,
            VehicleType = SUVCategory,
            Year = DateTime.MinValue,
        };
        var testVehicle2 = new Vehicle
        {
            Details = "Test details 2",
            Location = "Test location 2",
            Mileage = 12345,
            Power = 200,
            Make = "TestVehicle2",
            Model = "Test model 2",
            AverageDivingRange = 600,
            Price = 12345,
            Owner = agent,
            VehicleTypeId = 2,
            VehicleType = coupe,
            Year = DateTime.MinValue,
        };
        var testVehicle3 = new Vehicle
        {
            Details = "Test details 2",
            Location = "Test location 2",
            Mileage = 1234567,
            Power = 200,
            Make = "TestVehicle2",
            Model = "Test model 2",
            AverageDivingRange = 600,
            Price = 1234567,
            Owner = agent,
            VehicleTypeId = 2,
            VehicleType = coupe,
            Year = DateTime.MinValue,
        };
        await repository.AddAsync(testVehicle);
        await repository.AddAsync(testVehicle2);
        await repository.AddAsync(testVehicle3);
        await repository.SaveChangesAsync();

        List<Vehicle> vehicles = new()
        {
            testVehicle,
            testVehicle2,
            testVehicle3
        };

        var result = await vehicleService.AllAsync(sorting: VehicleFiltering.Price);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.TotalVehiclesCount - 3, Is.EqualTo(vehicles.Count));
    }

    [Test]
    public async Task AllAsync_Returns_Correct_Vehicles_When_Searching_By_Term()
    {
        // Arrange
        var searchTerm = "test";
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

        await repository.AddAsync(testVehicle);
        await repository.SaveChangesAsync();

        var result = await vehicleService.AllAsync(searchTerm: searchTerm);

        Assert.That(result, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(result.Vehicles.Count(), Is.EqualTo(1));
            Assert.That(result.TotalVehiclesCount, Is.EqualTo(1));
        });
    }

    [Test]
    public async Task CategoryExistsAsync_Returns_True_When_Category_Exists()
    {
        int existingCategoryId = 1;
        var existingCategory = new Category { Id = existingCategoryId };
        await dbContext.Categories.AddAsync(existingCategory);

        var result = await vehicleService.CategoryExistsAsync(existingCategoryId);

        Assert.That(result, Is.True);
    }

    [Test]
    public async Task CategoryExistsAsync_Returns_False_When_Category_Does_Not_Exist()
    {
        int nonExistingCategoryId = 999;

        var result = await vehicleService.CategoryExistsAsync(nonExistingCategoryId);

        Assert.That(result, Is.False);
    }

    [Test]
    public async Task GetVehicleByOwnerIdAsync_Returns_Correct_Vehicle()
    {
        var testVehicle = new Vehicle
        {

            Details = "Test details",
            Location = "Test location",
            Make = "Test make",
            Mileage = 10000,
            Power = 150,
            Model = "Test model",
            AverageDivingRange = 500,
            OwnerId = 1,
            Price = 50000,
            Title = "Test title",
            VehicleTypeId = 1,
            Year = DateTime.MinValue
        };

        await repository.AddAsync(testVehicle);
        await repository.SaveChangesAsync();

        // Act
        var result = await vehicleService.GetVehicleByOwnerIdAsync(testVehicle.Id);
        Assert.Multiple(() =>
        {

            // Assert
            Assert.That(result.Details, Is.EqualTo("Test details"));
            Assert.That(result.Location, Is.EqualTo("Test location"));
            Assert.That(result.Make, Is.EqualTo("Test make"));
            Assert.That(result.Mileage, Is.EqualTo(10000));
            Assert.That(result.Power, Is.EqualTo(150));
            Assert.That(result.Model, Is.EqualTo("Test model"));
            Assert.That(result.AverageDivingRange, Is.EqualTo(500));
            Assert.That(result.OwnerId, Is.EqualTo(1));
            Assert.That(result.Price, Is.EqualTo(50000));
            Assert.That(result.Title, Is.EqualTo("Test title"));
            Assert.That(result.Year, Is.EqualTo(DateTime.MinValue));
        });
    }

    [Test]
    public async Task Delete_Vehicle_Async_Works_Propertly()
    {
        var testVehicle = new Vehicle
        {
            Details = "Test details",
            Location = "Test location",
            Make = "Test make",
            Mileage = 10000,
            Power = 150,
            Model = "Test model",
            AverageDivingRange = 500,
            OwnerId = 1,
            Price = 50000,
            Title = "Test title",
            VehicleTypeId = 1,
            Year = DateTime.MinValue
        };

        await repository.AddAsync(testVehicle);
        await repository.SaveChangesAsync();

        await vehicleService.DeleteVehicleAsync(testVehicle.Id);

        Vehicle vehicle = await repository.GetByIdAsync<Vehicle>(testVehicle.Id);

        Assert.That(vehicle, Is.Null);
    }

    [Test]
    public async Task AllCategoriesAsync_ReturnsCategories()
    {
        var testCategory = new Category
        {
            Name = "Test",
        };

        await repository.AddAsync(testCategory);
        await repository.SaveChangesAsync();

        var cat = await vehicleService.AllCategoriesAsync();

        var category = cat.Where(e => e.Name == "Test").FirstOrDefault();

        Assert.That(category.Name, Is.EqualTo("Test"));
    }

    [Test]
    public async Task Vehicle_Details_Works_Propertly()
    {
        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"

        };
        var testVehicle = new Vehicle
        {
            Details = "Test details",
            Location = "Test location",
            Make = "Test make",
            Mileage = 10000,
            Power = 150,
            Model = "Test model",
            AverageDivingRange = 500,
            Price = 50000,
            Title = "Test title",
            Owner = agent,
            VehicleTypeId = 1,
            Year = DateTime.MinValue,
            ImageUrls = "ImageUrls",

        };
        await repository.AddAsync(agent);
        await repository.AddAsync(testVehicle);
        await repository.SaveChangesAsync();

        var result = await vehicleService.VehicleDetailsByIdAsync(testVehicle.Id);

        Assert.Multiple(() =>
        {
            Assert.That(result.Details, Is.EqualTo("Test details"));
            Assert.That(result.Location, Is.EqualTo("Test location"));
            Assert.That(result.Make, Is.EqualTo("Test make"));
            Assert.That(result.Mileage, Is.EqualTo(10000));
            Assert.That(result.Model, Is.EqualTo("Test model"));
            Assert.That(result.Price, Is.EqualTo(50000));
            Assert.That(result.Title, Is.EqualTo("Test title"));
            Assert.That(result.Year, Is.EqualTo(DateTime.MinValue));
        });
    }

    [Test]
    public async Task Owner_Exists_By_Id_Works_Propertly()
    {


        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"

        };
        var testVehicle = new Vehicle
        {
            Details = "Test details",
            Location = "Test location",
            Make = "Test make",
            Mileage = 10000,
            Power = 150,
            Model = "Test model",
            AverageDivingRange = 500,
            Price = 50000,
            Title = "Test title",
            Owner = agent,
            VehicleTypeId = 1,
            Year = DateTime.MinValue,
            ImageUrls = "ImageUrls",

        };
        await repository.AddAsync(agent);
        await repository.AddAsync(testVehicle);
        await repository.SaveChangesAsync();

        var result = await vehicleService.OwnerExistsByIdAsync(testVehicle.OwnerId);

        Assert.That(result, Is.True);
    }
    [Test]
    public async Task OwnerExistsByIdAsync_Returns_False_When_Owner_Does_Not_Exist()
    {
        var nonExistentOwnerId = 999;

        var result = await vehicleService.OwnerExistsByIdAsync(nonExistentOwnerId);

        Assert.That(result, Is.False);
    }
    [Test]
    public async Task HasAgentWithIdAsync_Returns_True_When_Agent_Exists()
    {
        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"

        };
        var testVehicle = new Vehicle
        {
            Details = "Test details",
            Location = "Test location",
            Make = "Test make",
            Mileage = 10000,
            Power = 150,
            Model = "Test model",
            AverageDivingRange = 500,
            Price = 50000,
            Title = "Test title",
            Owner = agent,
            VehicleTypeId = 1,
            Year = DateTime.MinValue,
            ImageUrls = "ImageUrls",
        };
        await repository.AddAsync(testVehicle);
        await repository.SaveChangesAsync();

        var result = await vehicleService.HasAgentWithIdAsync(testVehicle.Id, agent.User.Id);

        Assert.That(result, Is.True);
    }
    [Test]
    public async Task UpdateVehicleAsync_Updates_Vehicle_Correctly()
    {
        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"

        };
        var testVehicle = new Vehicle
        {
            Title = "Test title",
            ImageUrls = "ImageUrls",
            Make = "Test make",
            Details = "Test details",
            Location = "Test location",
            Mileage = 10000,
            Power = 150,
            Model = "Test model",
            AverageDivingRange = 500,
            Price = 50000,
            Owner = agent,
            VehicleTypeId = 1,
            Year = DateTime.MinValue,
        };
        await repository.AddAsync(testVehicle);
        await repository.SaveChangesAsync();

        var updatedVehicle = new VehicleCreationServiceModel
        {
            Title = "Updated Title",
            ImageUrl = "Updated ImageUrl",
            Make = "Updated make",
            Details = "Updated details",
            Location = "Updated location",
            Mileage = 10000,
            Power = 150,
            Model = "Updated model",
            AverageDivingRange = 500,
            Price = 50000,
            VehicleTypeId = 1,
            Year = DateTime.MinValue,
        };


        await vehicleService.UpdateVehicleAsync(testVehicle.Id, updatedVehicle);

        var updatedVehicleFromRepo = await repository.GetByIdAsync<Vehicle>(testVehicle.Id);

        Assert.That(updatedVehicleFromRepo, Is.Not.Null);
        Assert.Multiple(() =>
        {
            Assert.That(updatedVehicleFromRepo.Title, Is.EqualTo(updatedVehicle.Title));
            Assert.That(updatedVehicleFromRepo.ImageUrls, Is.EqualTo(updatedVehicle.ImageUrl));
        });
    }

    [Test]
    public async Task AllVehiclesByAgentIdAsync_Returns_All_Vehicles_For_Agent()
    {
        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"
        };

        var vehicle = new Vehicle
        {
            Details = "Test details",
            Location = "Test location",
            Mileage = 10000,
            Power = 150,
            Make = "TestVehicle1",
            Model = "Test model",
            AverageDivingRange = 500,
            Price = 50000,
            Owner = agent,
            VehicleTypeId = 1,
            Year = DateTime.MinValue,
        };
        var vehicle1 = new Vehicle
        {
            Details = "Test AllVehiclesByAgentIdAsync_Returns_All 2",
            Location = "Test location 2",
            Mileage = 20000,
            Power = 200,
            Make = "TestVehicle2",
            Model = "Test model 2",
            AverageDivingRange = 600,
            Price = 60000,
            Owner = agent,
            VehicleTypeId = 1,
            Year = DateTime.MinValue,
        };

        await repository.AddAsync(vehicle);
        await repository.AddAsync(vehicle1);
        await repository.SaveChangesAsync();

        var result = await vehicleService.AllVehiclesByAgentIdAsync(agent.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));

    }
    [Test]
    public async Task VehicleExistsByIdAsync_Returns_False_When_Vehicle_Does_Not_Exist()
    {
        var vehicleId = 2345;

        var result = await vehicleService.VehicleExistsByIdAsync(vehicleId);

        Assert.That(result, Is.False);
    }
    [Test]
    public async Task GetAllAsync_Returns_All_Vehicles_For_Agent()
    {
        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"
        };

        var testVehicle = new Vehicle
        {
            Details = "Test GetAllAsync_Returns_All_Vehicles 2",
            Location = "Test location 2",
            Mileage = 20000,
            Power = 200,
            Make = "TestVehicle2",
            Model = "Test model 2",
            AverageDivingRange = 600,
            Price = 60000,
            Owner = agent,
            VehicleTypeId = 1,
            Year = DateTime.MinValue,
        };
        await repository.AddAsync(testVehicle);
        await repository.SaveChangesAsync();


        var result = await vehicleService.GetAllAsync(agent.Id);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count(), Is.EqualTo(1));
    }

    [Test]
    public async Task GetAllAsync_Returns_Empty_List_When_Agent_Has_No_Vehicles()
    {
        var agentId = 76;

        var result = await vehicleService.GetAllAsync(agentId);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Any(), Is.False);
    }
    [Test]
    public async Task GetVehicleByIdAsync_WithValidId_ReturnsVehicle()
    {
        // Arrange
        var agent = new Agent()
        {
            User = new AppUser { UserName = "TESTYTEST", },
            Email = "test@tes.te",
            Location = "testTesttest"
        };
        dbContext.Add(agent);
        dbContext.SaveChanges();
        var expectedVehicle = new Vehicle
        {
            Title = "Test Vehicle",
            Year = DateTime.MaxValue,
            Make = "Test Make",
            Model = "Test Model",
            Mileage = 10000,
            Location = "Test Location",
            AverageDivingRange = 300,
            Price = 25000,
            Power = 200,
            Details = "Test Details",
            VehicleTypeId = 1,
            OwnerId = agent.Id,
            ImageUrls = "test-url.jpg"
        };
        dbContext.Vehicles.Add(expectedVehicle);
        dbContext.SaveChanges();

        // Act
        var result = await vehicleService.GetVehicleByIdAsync(expectedVehicle.Id);

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(expectedVehicle.Id, result.Id);
        // Add more assertions for other properties if needed
    }

    [TearDown]
    public void TearDown()
    {
        dbContext.Dispose();
    }

}

