using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Car
{
    [Column("CarId")]
    public Guid Id { get; set; }
    public string? PlateNumber { get; set; }
    public string? SerialNumber { get; set; }
    public string CarModel { get; set; }
    public string? BatteryCapacity { get; set; }
    
    [ForeignKey("User")]
    public string? UserId { get; set; }
    public User? User { get; set; }
}