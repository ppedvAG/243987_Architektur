using ppedv.CrustControl.Model.DomainModel;
using ppedv.CrustControl.Web.Api.Model;

namespace ppedv.CrustControl.Web.Api.Mapper
{
    public class PizzaMapper
    {
        public PizzaDTO MapToDTO(Pizza pizza)
        {
            return new PizzaDTO
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                Toppings = pizza.Toppings.Select(t => t.Name).ToArray()
            };
        }

        public Pizza MapToEntity(PizzaDTO pizzaDTO)
        {
            return new Pizza
            {
                Id = pizzaDTO.Id,
                Name = pizzaDTO.Name,
                Price = pizzaDTO.Price,
                Toppings = pizzaDTO.Toppings.Select(t => new Topping { Name = t }).ToList()
            };
        }
    }
}
