using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class RobotConfiguration : IEntityTypeConfiguration<Robot>
{
    public void Configure(EntityTypeBuilder<Robot> builder)
    {
        builder.HasData(
            new Robot
            {
                Id = new Guid("1f3e9b74-abc1-48a7-901b-caf65e67e196"),
                SerialNumber = "0000011",
                TechnicalStatus = "Good",
                RobotStationId = new Guid("1aec523e-e4ef-4876-bb18-09526ad77e29")
            }
        );
    }
}