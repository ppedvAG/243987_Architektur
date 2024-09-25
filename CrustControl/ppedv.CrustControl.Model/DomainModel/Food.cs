namespace ppedv.CrustControl.Model.DomainModel;

using System.Collections.Generic;

public abstract class Food : Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    // Navigation Properties
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}


