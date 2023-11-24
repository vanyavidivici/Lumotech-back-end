using Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository;

public class RepositoryContext : IdentityDbContext<User>
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new CarConfiguration());
        modelBuilder.ApplyConfiguration(new LocationConfiguration());
        modelBuilder.ApplyConfiguration(new RobotStationConfiguration());
        modelBuilder.ApplyConfiguration(new RobotConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }

    public DbSet<Car>? Cars{ get; set; }
    public DbSet<Robot>? Robots { get; set; }
    public DbSet<RobotStation>? RobotStations { get; set; }
    public DbSet<Location>? Locations { get; set; }
    public DbSet<Subscription>? Subscriptions { get; set; }
    public DbSet<Order>? Orders { get; set; }
}