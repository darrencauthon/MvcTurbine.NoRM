using System;
using System.Linq;

namespace MvcTurbine.NoRM.Db
{
    public interface IRepository : IDisposable
    {
        void Add<T>(T objectToAdd);
        void Update<T>(T objectToUpdate);
        IQueryable<T> Retrieve<T>();
        void Delete<T>(T objectToDelete);
    }
}