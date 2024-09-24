﻿namespace ppedv.CrustControl.Model;

using System.Collections.Generic;

public abstract class Food : Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }

    // Navigation Properties
    public ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();
}

