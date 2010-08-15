namespace MvcTurbine.NoRM.Mongo
{
    public interface IMongoConnectionSettingsRetriever
    {
        MongoConnectionSettings GetSettings();
    }
}