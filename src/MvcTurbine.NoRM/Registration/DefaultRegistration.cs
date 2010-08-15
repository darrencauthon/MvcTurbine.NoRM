using MvcTurbine.ComponentModel;
using MvcTurbine.NoRM.Db;

namespace MvcTurbine.NoRM.Registration
{
    public class DefaultRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IMongoRepositoryFactory, MongoRepositoryFactory>();
            locator.Register<IMongoRepository, MongoRepository>();
            locator.Register<IMongoFactory, MongoFactory>();
            locator.Register<IMongoCollectionBuilder, MongoCollectionBuilder>();
        }
    }
}