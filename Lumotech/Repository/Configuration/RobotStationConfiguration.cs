using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class RobotStationConfiguration : IEntityTypeConfiguration<RobotStation>
{
    public void Configure(EntityTypeBuilder<RobotStation> builder)
    {
        builder.HasData(
            new RobotStation
            {
                Id = new Guid("1aec523e-e4ef-4876-bb18-09526ad77e29"),
                StationName = "Andromeda_1",
                LocationId = new Guid("7D95A214-B50C-4AD3-8D06-15787D1DB8F9")
            }
        );
    }
}