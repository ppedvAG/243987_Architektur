namespace ppedv.CrustControl.Model;

using System.Collections.Generic;

public class Pizza : Food
{
    // Navigation Properties
    public ICollection<Topping> Toppings { get; set; } = new HashSet<Topping>();
}


