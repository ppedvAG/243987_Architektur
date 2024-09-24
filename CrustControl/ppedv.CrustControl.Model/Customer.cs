namespace ppedv.CrustControl.Model;

using System.Collections.Generic;

public class Customer : Entity
{
    public required string Name { get; set; }
    public string? Address { get; set; }

    public ICollection<Order> BillingOrder { get; set; } = new HashSet<Order>();
    public ICollection<Order> DeliveryOrder { get; set; } = new HashSet<Order>();
}


