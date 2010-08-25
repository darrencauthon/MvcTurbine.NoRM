namespace MvcTurbine.NoRM.Db
{
    public interface IMongoConnectionSettingsRetriever
    {
        MongoConnectionSettings GetSettings();
    }
}