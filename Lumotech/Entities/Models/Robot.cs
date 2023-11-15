using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Robot
{
    [Column("RobotId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Serial number is a required field.")]
    public string? SerialNumber { get; set; }
    
    [Required(ErrorMessage = "Technical status is a required field.")]
    public string? TechnicalStatus { get; set; }
    
    public string? GpsLongitude { get; set; }
    public string? GpsLatitude { get; set; }
    
    [ForeignKey(nameof(RobotStation))]
    public Guid RobotStationId { get; set; }
    public RobotStation? RobotStation { get; set; }
}