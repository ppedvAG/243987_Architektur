namespace ppedv.CrustControl.Model.DomainModel;

public class OrderItem : Entity
{
    public virtual required Order Order { get; set; }
    public int Amount { get; set; }

    public virtual required Food FoodItem { get; set; }
}


