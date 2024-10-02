using ppedv.CrustControl.Model.Contracts.Data;
using ppedv.CrustControl.Model.Contracts.Services;
using ppedv.CrustControl.Model.DomainModel;


namespace ppedv.CrustControl.Logic
{
    public class PizzaService : IPizzaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PizzaService(IUnitOfWork repository)
        {
            this._unitOfWork = repository;
        }

        public Pizza? GetMostOrderdPizzaOfMonth(int month)
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(month, 12, nameof(month));
            ArgumentOutOfRangeException.ThrowIfLessThan(month, 1, nameof(month));

            return _unitOfWork.OrderRepo.Query().Where(x => x.Date.Month == month)
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
