using AuctionVehicleProperty.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuctionVehicleProperty.Infrastructure.Data.SeedingData
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            var data = new SeedData();

            builder.HasData(new Category[] { data.SUVCategory,
                data.CoupeCategory, data.HatchbackCategory,
                data.PickupCategory,data.SedanCategory,
                data.ConvertibleCategory });
        }

    }
}
