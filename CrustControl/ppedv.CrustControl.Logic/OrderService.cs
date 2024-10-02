using ppedv.CrustControl.Model.Contracts.Data;
using ppedv.CrustControl.Model.Contracts.Services;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Logic
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPizzaService _pizzaService;

        public OrderService(IUnitOfWork unitOfWork, IPizzaService pizzaService)
        {
            this._unitOfWork = unitOfWork;
            this._pizzaService = pizzaService;
        }

        public bool IsOrderVegan(Order order)
        {
            ArgumentNullException.ThrowIfNull(order);
            ArgumentNullException.ThrowIfNull(order.Items);

            foreach (var item in order.Items.Select(x => x.FoodItem).OfType<Pizza>())
            {
                if (_pizzaService.IsVegan(item))
                    return false;
            }
            return true;
        }

    }
}
