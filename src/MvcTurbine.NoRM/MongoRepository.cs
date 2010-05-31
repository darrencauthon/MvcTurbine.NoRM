using System;
using System.Linq;
using Norm.Collections;

namespace MvcTurbine.NoRM
{
    public class MongoRepository<T>
    {
        private readonly MongoCollection<T> mongoCollection;

        public MongoRepository(MongoCollection<T> mongoCollection)
        {
            this.mongoCollection = mongoCollection;
        }

        public void Add(T objectToAdd)
        {
            mongoCollection.Insert(objectToAdd);
        }

        public void Update(T objectToUpdate)
        {
            mongoCollection.Save(objectToUpdate);
        }

        public IQueryable<T> Retrieve()
        {
            return mongoCollection.Find().AsQueryable();
        }

        public void Delete(T objectToDelete)
        {
            mongoCollection.Delete(objectToDelete);
        }
    }
}