namespace ppedv.CrustControl.Model;

public class OrderItem : Entity
{
    public required Order Order { get; set; }
    public int Amount { get; set; }

    public required Food FoodItem { get; set; }
}


