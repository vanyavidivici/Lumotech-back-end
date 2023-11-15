using System.ComponentModel.DataAnnotations.Schema;
using Entities.Enums;

namespace Entities.Models;

public class Subscription
{
    [Column("SubscriptionId")]
    public Guid Id { get; set; }
    public string? SubscriptionName { get; set; }
    public int MaxCars { get; set; }
}