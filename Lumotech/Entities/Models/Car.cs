using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Car
{
    [Column("CarId")]
    public Guid Id { get; set; }
    [Required(ErrorMessage = "PlateNumber is a required field.")]
    public string? PlateNumber { get; set; }
    [Required(ErrorMessage = "SerialNumber is a required field.")]
    public string? SerialNumber { get; set; }
    [Required(ErrorMessage = "CarModel is a required field.")]
    public string? CarModel { get; set; }
    [Required(ErrorMessage = "BatteryCapacity is a required field.")]
    public double? BatteryCapacity { get; set; }
    [ForeignKey("User")]
    public string? UserId { get; set; }
    public User? User { get; set; }
}