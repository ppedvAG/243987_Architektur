﻿namespace ppedv.CrustControl.Model.DomainModel;

using System.Collections.Generic;

public class Topping : Entity
{
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public bool Vegan { get; set; }
    public bool Vegetarian { get; set; }

    // Navigation Properties
    public virtual ICollection<Pizza> Pizzas { get; set; } = new HashSet<Pizza>();
}


