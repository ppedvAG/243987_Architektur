using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Logic
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repository;
        private readonly IPizzaService pizzaService;

        public OrderService(IRepository repository, IPizzaService pizzaService)
        {
            this.repository = repository;
            this.pizzaService = pizzaService;
        }

        public bool IsOrderVegan(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);
            ArgumentNullException.ThrowIfNull(order.Items);

            foreach (var item in order.Items.Select(x => x.FoodItem).OfType<Pizza>())
            {
                if (pizzaService.IsVegan(item))
                    return false;
            }
            return true;
        }

    }
}
