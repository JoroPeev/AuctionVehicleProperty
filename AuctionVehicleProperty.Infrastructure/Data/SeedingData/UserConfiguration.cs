using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionVehicleProperty.Infrastructure.Data.SeedingData
{
    internal class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var data = new SeedData();

            builder.HasData(new AppUser[] { data.AgentUser, data.GuestUser ,data.SecondGuestUser, data.AdminUser });
        }
    }
}
