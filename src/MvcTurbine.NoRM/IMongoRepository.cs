using System;
using System.Linq;

namespace MvcTurbine.NoRM
{
    public interface IMongoRepository<T> : IDisposable
    {
        void Add(T objectToAdd);

        void Update(T objectToUpdate);

        IQueryable<T> Retrieve();

        void Delete(T objectToDelete);
    }
}