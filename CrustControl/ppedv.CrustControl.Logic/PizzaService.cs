using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;


namespace ppedv.CrustControl.Logic
{
    public class PizzaService : IPizzaService
    {
        private readonly IRepository repository;

        public PizzaService(IRepository repository)
        {
            this.repository = repository;
        }

        public Pizza? GetMostOrderdPizzaOfMonth(int month)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(month, 12, nameof(month));
            ArgumentOutOfRangeException.ThrowIfLessThan(month, 1, nameof(month));

            return repository.Query<Order>().Where(x => x.Date.Month == month)
                                            .SelectMany(x => x.Items)
                                            .Select(x => x.FoodItem)
                                            .OfType<Pizza>()
                                            .GroupBy(x => x)
                                            .OrderByDescending(x => x.Count())
                                            .Select(x => x.Key)
                                            .FirstOrDefault();
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
