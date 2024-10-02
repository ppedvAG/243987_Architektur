using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Model.Contracts.Services
{
    public interface IOrderService
    {
        bool IsOrderVegan(Order order);
    }
}