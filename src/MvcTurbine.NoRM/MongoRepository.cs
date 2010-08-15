using System;
using System.Linq;
using Norm;
using Norm.Collections;

namespace MvcTurbine.NoRM
{
    public interface IMongoRepository : IDisposable
    {
        void Add<T>(T objectToAdd);
        void Update<T>(T objectToUpdate);
        IQueryable<T> Retrieve<T>();
        void Delete<T>(T objectToDelete);
    }

    public class MongoRepository : IMongoRepository
    {
        private readonly Mongo mongo;

        public void Add<T>(T objectToAdd)
        {
            GetTheCollection<T>().Insert(objectToAdd);
        }

        private IMongoCollection<T> GetTheCollection<T>()
        {
            return mongo.GetCollection<T>();
        }

        public void Update<T>(T objectToUpdate)
        {
            GetTheCollection<T>().Save(objectToUpdate);
        }

        public IQueryable<T> Retrieve<T>()
        {
            return GetTheCollection<T>().Find().AsQueryable();
        }

        public void Delete<T>(T objectToDelete)
        {
            GetTheCollection<T>().Delete(objectToDelete);
        }

        public void Dispose()
        {
            mongo.Dispose();
        }
    }
}