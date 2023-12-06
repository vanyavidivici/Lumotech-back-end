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
                Id = new Guid("0f4c011c-a92f-42de-8343-165fc07926d6"),
                PlateNumber = "AA2030AA",
                SerialNumber = "VD9485445KD",
                CarModel = "Tesla Model X",
                BatteryCapacity = 100.0
            }
        );
    }
}