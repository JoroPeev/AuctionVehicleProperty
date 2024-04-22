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





    }
}
