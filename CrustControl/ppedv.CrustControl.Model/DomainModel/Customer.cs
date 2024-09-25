namespace ppedv.CrustControl.Model.DomainModel;

using System.Collections.Generic;

public class Customer : Entity
{
    public required string Name { get; set; }
    public string? Address { get; set; }

    public virtual ICollection<Order> BillingOrder { get; set; } = new HashSet<Order>();
    public virtual ICollection<Order> DeliveryOrder { get; set; } = new HashSet<Order>();
}


