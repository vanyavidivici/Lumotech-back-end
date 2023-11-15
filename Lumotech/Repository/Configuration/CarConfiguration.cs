using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.HasData(
            new Car
            {
                Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                PlateNumber = "AA2030AA",
                SerialNumber = "VD9485445KD",
                CarModel = "Tesla Model X",
                BatteryCapacity = "100.0",
            }
        );
    }
}