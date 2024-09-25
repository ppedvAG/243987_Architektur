namespace ppedv.CrustControl.Model.DomainModel;

using System;
using System.Collections.Generic;

public class Order : Entity
{
    public DateTime Date { get; set; }

    public virtual Customer? Delivery { get; set; }
    public virtual required Customer Billing { get; set; }
    public virtual ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
}


