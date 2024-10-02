using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Model.Contracts.Data
{
    public interface IUnitOfWork
    {
        IRepository<Pizza> PizzaRepo { get; }
        IRepository<Order> OrderRepo { get; }
        ICustomerRepository CustomerRepo { get; }
        IRepository<Topping> ToppingRepo { get; }

        int SaveAll();
    }

    public interface ICustomerRepository : IRepository<Customer>
    {
        void KillAllCustomerBySp();
    }

    public interface IRepository<T> where T : Entity
    {
        T? GetById(int id);
        IQueryable<T> Query();

        void Add(T item);
        void Delete(T item);
        void Update(T item);
    }
}
