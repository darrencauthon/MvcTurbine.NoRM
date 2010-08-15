using Norm;

namespace MvcTurbine.NoRM
{
    public interface IMongoFactory
    {
        IMongo CreateMongo();
    }
}