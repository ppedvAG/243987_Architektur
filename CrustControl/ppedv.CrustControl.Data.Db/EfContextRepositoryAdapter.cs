using Microsoft.EntityFrameworkCore;
using ppedv.CrustControl.Model.Contracts.Data;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Data.Db
{
    public class EfContextUnitOfWorkAdapter : IUnitOfWork
    {
        EfContext _context;
        public EfContextUnitOfWorkAdapter(string conString)
        {
            _context = new EfContext(conString);
        }

        public IRepository<Pizza> PizzaRepo => new EfContextRepositoryAdapter<Pizza>(_context);

        public IRepository<Order> OrderRepo => new EfContextRepositoryAdapter<Order>(_context);

        public ICustomerRepository CustomerRepo => new EfCustomerRepository(_context);

        public IRepository<Topping> ToppingRepo => new EfContextRepositoryAdapter<Topping>(_context);

        public int SaveAll()
        {
            return _context.SaveChanges();
        }
    }

    public class EfCustomerRepository : EfContextRepositoryAdapter<Customer>, ICustomerRepository
    {
        public EfCustomerRepository(EfContext context) : base(context)
        { }

        public void KillAllCustomerBySp()
        {
            _context.Database.ExecuteSqlRaw("EXEC KillAllCustomers");
        }
    }

    public class EfContextRepositoryAdapter<T> : IRepository<T> where T : Entity
    {
        protected readonly EfContext _context;

        public EfContextRepositoryAdapter(EfContext context)
        {
            this._context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public void Delete(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public IQueryable<T> Query()
        {
            return _context.Set<T>();
        }

        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
