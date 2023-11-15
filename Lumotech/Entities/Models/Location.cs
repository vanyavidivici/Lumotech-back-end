using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Location
{
    [Column("LocationId")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Country is a required field.")]
    public string? Country { get; set; }
    
    [Required(ErrorMessage = "City is a required field.")]
    public string? City { get; set; }
}