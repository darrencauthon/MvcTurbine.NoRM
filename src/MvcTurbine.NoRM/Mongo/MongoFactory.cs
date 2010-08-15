using Norm;

namespace MvcTurbine.NoRM.Mongo
{
    public interface IMongoFactory
    {
        IMongo CreateMongo();
    }

    public class MongoFactory : IMongoFactory
    {
        private readonly IMongoConnectionSettingsRetriever mongoConnectionSettingsRetriever;

        public MongoFactory(IMongoConnectionSettingsRetriever mongoConnectionSettingsRetriever)
        {
            this.mongoConnectionSettingsRetriever = mongoConnectionSettingsRetriever;
        }

        public IMongo CreateMongo()
        {
            var settings = mongoConnectionSettingsRetriever.GetSettings();
            return new Mongo(settings.DatabaseName, settings.Server, settings.Port, string.Empty);
        }
    }
}