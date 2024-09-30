using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Model.Contracts
{
    public interface IRepository
    {
        T? GetById<T>(int id) where T : Entity;
        //IEnumerable<T> GetAll<T>() where T : Entity;
        IQueryable<T> Query<T>() where T : Entity;

        void Add<T>(T item) where T : Entity;
        void Delete<T>(T item) where T : Entity;
        void Update<T>(T item) where T : Entity;

        int SaveAll(); 
    }
}
