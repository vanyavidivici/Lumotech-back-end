using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class RobotStation
{
    public Guid RobotStationId { get; set; }
    
    [Required(ErrorMessage = "Company address is a required field.")]
    [MaxLength(60, ErrorMessage = "Maximum length for the Station name is 60 characters.")]
    public string? StationName { get; set; }
    
    public string? GpsLongitude { get; set; }
    public string? GpsLatitude { get; set; }
    
    [ForeignKey(nameof(Location))]
    public Guid LocationId { get; set; }
    public Location? Location { get; set; }

    public ICollection<Robot>? Robots { get; set; }
}