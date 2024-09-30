using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Data.Db
{
    public class EfContextRepositoryAdapter : IRepository
    {
        EfContext context;
        public EfContextRepositoryAdapter(string conString)
        {
            context = new EfContext(conString);
        }

        public void Add<T>(T item) where T : Entity
        {
            context.Set<T>().Add(item);
        }

        public void Delete<T>(T item) where T : Entity
        {
            context.Set<T>().Remove(item);
        }

        //public IEnumerable<T> GetAll<T>() where T : Entity
        //{
        //    return context.Set<T>().ToList();
        //}
        public IQueryable<T> Query<T>() where T : Entity
        {
            return context.Set<T>();
        }


        public T? GetById<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

 

        public int SaveAll()
        {
            return context.SaveChanges();
        }

        public void Update<T>(T item) where T : Entity
        {
            context.Set<T>().Update(item);
        }
    }
}
