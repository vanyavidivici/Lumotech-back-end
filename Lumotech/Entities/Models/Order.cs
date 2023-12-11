using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Order
{
    [Column("OrderId")]
    public Guid Id { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ArrivalTime { get; set; }
    
    public string? Note { get; set; }
    [Required(ErrorMessage = "Status is a required field.")]
    public string? Status { get; set; }
    
    public Guid CarId { get; set; }
    public Car? Car { get; set; }
    
    public Guid RobotId { get; set; }
    public Robot? Robot { get; set; }

    public string? GpsLatitude { get; set; }
    public string? GpsLongitude { get; set; }
    
    [ForeignKey("User")]
    public string? UserId { get; set; }
    public User? User { get; set; }
}