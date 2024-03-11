using AuctionVehicleProperty.Infrastructure.Data.Models;
using AuctionVehicleProperty.Infrastructure.Data.SeedingData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AuctionVehicleProperty.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Agent> Agents { get; set; } = null!;
        public DbSet<Auction> Auctions { get; set; } = null!;
        public DbSet<Bid> Bids { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new VehicleConfiguration());
            builder.ApplyConfiguration(new AuctionConfiguration());
            builder.ApplyConfiguration(new BidConfiguration());

            builder.Entity<Bid>(e =>
            {
                e.HasKey(k => new { k.AuctionId, k.CustomerId });
            });

            base.OnModelCreating(builder);
        }
    }
}