namespace MvcTurbine.NoRM
{
    public interface IMongoRepositoryFactory
    {
        IMongoRepository<T> GetRepository<T>();
    }
}