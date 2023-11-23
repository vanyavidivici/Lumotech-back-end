using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasData(
            new Location
            {
                Id = new Guid("7d95a214-b50c-4ad3-8d06-15787d1db8f9"),
                Country = "Germany",
                City = "Berlin"
            }
        );
    }
}