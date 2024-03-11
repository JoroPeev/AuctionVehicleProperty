using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionVehicleProperty.Infrastructure.Data.SeedingData
{
    internal class VehicleConfiguration: IEntityTypeConfiguration<Vehicle>
    {

        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            var data = new SeedData();

            builder.HasData(new Vehicle[] { data.ElectricVehicle,data.HybridVehicle });
        }

    }
}
