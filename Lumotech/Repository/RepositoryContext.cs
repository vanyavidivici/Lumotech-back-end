using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
    }
    
    public DbSet<Car>? Cars{ get; set; }
    public DbSet<Robot>? Robots { get; set; }
    public DbSet<RobotStation>? RobotStations { get; set; }
    public DbSet<Location>? Locations { get; set; }
    public DbSet<Subscription>? Subscriptions { get; set; }
    public DbSet<Order>? Orders { get; set; }
}