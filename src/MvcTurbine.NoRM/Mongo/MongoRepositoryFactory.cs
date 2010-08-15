using System;

namespace MvcTurbine.NoRM.Mongo
{
    public interface IMongoRepositoryFactory : IDisposable
    {
    }

    public class MongoRepositoryFactory : IMongoRepositoryFactory
    {
        public void Dispose()
        {
        }

        public IMongoRepository GetRepository()
        {
            return new MongoRepository(null);
        }
    }
}