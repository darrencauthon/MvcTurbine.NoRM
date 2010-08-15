using Norm.Collections;

namespace MvcTurbine.NoRM
{
    public interface IMongoCollectionBuilder
    {
        IMongoCollection<T> GetCollection<T>();
    }

    public class MongoCollectionBuilder : IMongoCollectionBuilder
    {
        private readonly IMongoFactory mongoFactory;

        public MongoCollectionBuilder(IMongoFactory mongoFactory)
        {
            this.mongoFactory = mongoFactory;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return mongoFactory.CreateMongo().GetCollection<T>();
        }
    }
}