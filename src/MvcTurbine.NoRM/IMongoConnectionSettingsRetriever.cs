namespace MvcTurbine.NoRM
{
    public interface IMongoConnectionSettingsRetriever
    {
        MongoConnectionSettings GetSettings();
    }
}