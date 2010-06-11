namespace MvcTurbine.NoRM
{
    public class MongoRepositoryFactory : IMongoRepositoryFactory
    {
        private readonly IMongoFactory mongoFactory;

        public MongoRepositoryFactory(IMongoFactory mongoFactory)
        {
            this.mongoFactory = mongoFactory;
        }

        public IMongoRepository<T> GetRepository<T>()
        {
            return new MongoRepository<T>(mongoFactory);
        }
    }
}