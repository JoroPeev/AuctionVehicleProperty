using AuctionVehicleProperty.Core.Contracts;
using AuctionVehicleProperty.Core.Services;
using AuctionVehicleProperty.Infrastructure.Data;
using AuctionVehicleProperty.Infrastructure.Data.Common;
using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuctionVehicleProperty.Test
{
    [TestFixture]
    public class AgentServiceTest
    {

        private IRepository repository;
        private IAgentService agentService;
        private ApplicationDbContext dbContext;

        [SetUp]
        public void Setup()
        {

            var configuration = new ConfigurationBuilder()
                .AddUserSecrets<AgentServiceTest>()
                .Build();

            var connectionString = configuration.GetConnectionString("TestConnection");

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            dbContext = new ApplicationDbContext(contextOptions);
            repository = new Repository(dbContext);
            agentService = new AgentService(repository);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
        }
        [Test]
        public async Task CreateAsync_Adds_New_Agent_To_Repository()
        {
            var user1 = new AppUser
            { FirstName = "Test", LastName = "Testov" };
            await repository.AddAsync(user1);
            await repository.SaveChangesAsync();

            var agent1 = new Agent
            { Email = "email1@example.com", Location = "Location 1", UserId = user1.Id };
            

            await agentService.CreateAsync(user1.Id, agent1.Email, agent1.Location);

            var createdAgent = await repository.AllReadOnly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == user1.Id && a.Email == agent1.Email && a.Location == agent1.Location);

            Assert.That(createdAgent, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(createdAgent.UserId, Is.EqualTo(user1.Id));
                Assert.That(createdAgent.Email, Is.EqualTo(agent1.Email));
                Assert.That(createdAgent.Location, Is.EqualTo(agent1.Location));
            });
        }

        [Test]
        public async Task ExistsByIdAsync_Returns_True_If_Agent_Exists()
        {
            var user1 = new AppUser
            { FirstName = "Test", LastName = "Testov" };
            await repository.AddAsync(user1);
            await repository.SaveChangesAsync();

            var agent1 = new Agent
            { Email = "email1@example.com", Location = "Location 1", UserId = user1.Id };
            await repository.AddAsync(agent1);
            await repository.SaveChangesAsync();

            var result = await agentService.ExistsByIdAsync(user1.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistsByIdAsync_Returns_False_If_Agent_Does_Not_Exist()
        {
            var userId = "testUserId";

            var result = await agentService.ExistsByIdAsync(userId);

            Assert.IsFalse(result);
        }
        [Test]
        public async Task GetAgentIdAsync_Returns_Agent_Id_If_Exists()
        {
            var user1 = new AppUser 
            { FirstName = "Test", LastName = "Testov" };
            await repository.AddAsync(user1);
            await repository.SaveChangesAsync();
           
            var agent1 = new Agent 
            { Email = "email1@example.com", Location = "Location 1", UserId = user1.Id };
            await repository.AddAsync(agent1);
            await repository.SaveChangesAsync();

            var result = await agentService.GetAgentIdAsync(user1.Id);

            Assert.That(result, Is.EqualTo(agent1.Id));
        }

        [Test]
        public async Task GetAgentIdAsync_Returns_Minus_One_If_Agent_Does_Not_Exist()
        {
            var userId = "testUserId"; 

            var result = await agentService.GetAgentIdAsync(userId);

            Assert.That(result, Is.EqualTo(-1));
        }
        [Test]
        public async Task GetAllAgentsAsync_Returns_All_Agents()
        {
            var user1 = new AppUser { FirstName = "Test", LastName = "Testov" };
            var user2 = new AppUser { FirstName = "test2", LastName = "Testoer4" };

            await repository.AddAsync(user1);
            await repository.AddAsync(user2);
            await repository.SaveChangesAsync();

            var agent1 = new Agent { Email = "email1@example.com", Location = "Location 1", UserId=user1.Id};
            var agent2 = new Agent { Email = "email2@example.com", Location = "Location 2", UserId = user2.Id };
    
            await repository.AddAsync(agent1);
            await repository.AddAsync(agent2);
            await repository.SaveChangesAsync();

            List<Agent> agents = new() { agent1, agent2 };

            var result = await agentService.GetAllAgentsAsync();

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(4));
            foreach (var agent in agents)
            {
                var mappedAgent = result.FirstOrDefault(a => a.Id == agent.Id);
                Assert.That(mappedAgent, Is.Not.Null);
                Assert.Multiple(() =>
                {
                    Assert.That(mappedAgent.Email, Is.EqualTo(agent.Email));
                    Assert.That(mappedAgent.Location, Is.EqualTo(agent.Location));
                });
            }
        }



    }
}
