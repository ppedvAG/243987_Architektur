namespace ppedv.CrustControl.Model;

using System;
using System.Collections.Generic;

public class Order : Entity
{
    public DateTime Date { get; set; }

    public Customer? Delivery { get; set; }
    public required Customer Billing { get; set; }
    public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
}


