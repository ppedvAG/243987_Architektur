using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Logic
{
    public interface IOrderService
    {
        bool IsOrderVegan(Order order);
    }
}