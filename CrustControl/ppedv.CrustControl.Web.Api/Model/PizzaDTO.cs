namespace ppedv.CrustControl.Web.Api.Model
{
    public class PizzaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public decimal Price { get; set; }
        public string[] Toppings { get; set; }  

    }
}
