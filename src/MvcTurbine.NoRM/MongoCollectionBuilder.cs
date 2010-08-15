using Norm;
using Norm.Collections;

namespace MvcTurbine.NoRM
{
    public interface IMongoCollectionBuilder
    {
        IMongoCollection<T> GetCollection<T>();
    }

    public class MongoCollectionBuilder : IMongoCollectionBuilder
    {
        private readonly IMongo mongo;

        public MongoCollectionBuilder(IMongo mongo)
        {
            this.mongo = mongo;
        }

        public IMongoCollection<T> GetCollection<T>()
        {
            return mongo.GetCollection<T>();
        }
    }
}