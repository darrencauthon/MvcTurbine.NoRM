using System.Linq;
using Norm;
using Norm.Collections;

namespace MvcTurbine.NoRM
{
    public class MongoRepository<T> : IMongoRepository<T>
    {
        private readonly Mongo mongo;
        private readonly MongoCollection<T> mongoCollection;

        public MongoRepository(IMongoFactory mongoFactory)
        {
            mongo = mongoFactory.CreateMongo();
            mongoCollection = mongo.GetCollection<T>();
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

        public void Dispose()
        {
            mongo.Dispose();
        }
    }
}