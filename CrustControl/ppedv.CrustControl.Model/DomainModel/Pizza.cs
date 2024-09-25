namespace ppedv.CrustControl.Model.DomainModel;

using System.Collections.Generic;

public class Pizza : Food
{
    // Navigation Properties
    public virtual ICollection<Topping> Toppings { get; set; } = new HashSet<Topping>();
}


