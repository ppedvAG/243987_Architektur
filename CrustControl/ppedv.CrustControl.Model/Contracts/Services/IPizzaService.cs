using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Model.Contracts.Services
{
    public interface IPizzaService
    {
        Pizza? GetMostOrderdPizzaOfMonth(int month);
        bool IsVegan(Pizza pizza);
        bool IsVegetarian(Pizza pizza);
    }
}