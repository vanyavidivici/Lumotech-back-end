using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class User
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? CompanyName { get; set; }
    public DateTime? SubscriptionExpirationDate { get; set; }
    
    [ForeignKey(nameof(Subscription))]
    public Guid SubscriptionId { get; set; }
    public Subscription? Subscription { get; set; }
    public ICollection<Car>? Cars { get; set; }
    public ICollection<Order>? Orders { get; set; }
}