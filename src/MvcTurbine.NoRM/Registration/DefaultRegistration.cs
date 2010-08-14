using MvcTurbine.ComponentModel;

namespace MvcTurbine.NoRM.Registration
{
    public class DefaultRegistration : IServiceRegistration
    {
        public void Register(IServiceLocator locator)
        {
            locator.Register<IMongoRepositoryFactory, MongoRepositoryFactory>();
        }
    }
}