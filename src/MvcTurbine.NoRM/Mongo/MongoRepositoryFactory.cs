using System;

namespace MvcTurbine.NoRM.Db
{
    public interface IMongoRepositoryFactory : IDisposable
    {
    }

    public class MongoRepositoryFactory : IMongoRepositoryFactory
    {
        public void Dispose()
        {
        }

        public IRepository GetRepository()
        {
            return new Repository(null);
        }
    }
}