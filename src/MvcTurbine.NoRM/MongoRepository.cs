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
        private readonly IMongoCollectionBuilder mongoCollectionBuilder;
        private readonly Mongo mongo;

        public MongoRepository(IMongoCollectionBuilder mongoCollectionBuilder)
        {
            this.mongoCollectionBuilder = mongoCollectionBuilder;
        }

        public void Add<T>(T objectToAdd)
        {
            GetTheCollection<T>().Insert(objectToAdd);
        }

        public void Update<T>(T objectToUpdate)
        {
            GetTheCollection<T>().Save(objectToUpdate);
        }

        private IMongoCollection<T> GetTheCollection<T>()
        {
            return mongoCollectionBuilder.GetCollection<T>();
        }

        public IQueryable<T> Retrieve<T>()
        {
            return GetTheCollection<T>().AsQueryable();
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