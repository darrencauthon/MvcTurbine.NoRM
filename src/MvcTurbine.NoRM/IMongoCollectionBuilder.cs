using System.Linq;
using Norm.Collections;

namespace MvcTurbine.NoRM
{
    public interface IMongoCollectionBuilder
    {
        IMongoCollection<T> GetCollection<T>();
    }
}