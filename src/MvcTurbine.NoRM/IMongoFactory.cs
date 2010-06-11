using Norm;

namespace MvcTurbine.NoRM
{
    public interface IMongoFactory
    {
        Mongo CreateMongo();
    }

    public class MongoFactory : IMongoFactory
    {
        public Mongo CreateMongo()
        {
            return new Mongo("TEST", "localhost", "27017", string.Empty);
        }
    }
}