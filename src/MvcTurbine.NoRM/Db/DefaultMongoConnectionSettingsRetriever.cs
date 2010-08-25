namespace MvcTurbine.NoRM.Db
{
    public class DefaultMongoConnectionSettingsRetriever : IMongoConnectionSettingsRetriever
    {
        private readonly IDefaultServerNameCalculator defaultServerNameCalculator;

        public DefaultMongoConnectionSettingsRetriever(IDefaultServerNameCalculator defaultServerNameCalculator)
        {
            this.defaultServerNameCalculator = defaultServerNameCalculator;
        }

        public MongoConnectionSettings GetSettings()
        {
            return new MongoConnectionSettings
                       {
                           Server = "localhost",
                           Port = "27017",
                           DatabaseName = defaultServerNameCalculator.CalculateName()
                       };
        }
    }
}