using System;
using MvcTurbine.ComponentModel;

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

            locator.Register<IMongoConnectionSettingsRetriever, 
                TempMongoConnectionSettingsRetriever>();
        }
    }

    public class TempMongoConnectionSettingsRetriever : IMongoConnectionSettingsRetriever{
        public MongoConnectionSettings GetSettings()
        {
            return new MongoConnectionSettings
                       {
                           DatabaseName = "Test",
                           Port = "27017",
                           Server = "localhost"
                       };
        }
    }
}