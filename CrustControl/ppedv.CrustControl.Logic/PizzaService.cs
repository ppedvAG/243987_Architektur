using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Logic
{
    public class PizzaService
    {
        private readonly IRepository repository;

        public PizzaService(IRepository repository)
        {
            this.repository = repository;
        }


        public Pizza GetMostOrderdPizzaOfMonth(int month)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(month, 12, nameof(month));
            ArgumentOutOfRangeException.ThrowIfLessThan(month, 1, nameof(month));

            throw new NotImplementedException();
        }

        public bool IsVegan(Pizza pizza)
        {
            return pizza.Toppings.All(x => x.Vegan && x.Vegetarian);
        }

        public bool IsVegetarian(Pizza pizza)
        {
            return pizza.Toppings.All(x => x.Vegetarian);
        }
    }
}
