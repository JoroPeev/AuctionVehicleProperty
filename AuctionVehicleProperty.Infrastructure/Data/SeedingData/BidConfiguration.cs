using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionVehicleProperty.Infrastructure.Data.SeedingData
{
    internal class BidConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            var data = new SeedData();

            builder.HasData(new Bid[] { data.GuestBid, data.SecondGuestBid});
        }
    }
}
