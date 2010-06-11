using Microsoft.Practices.Unity;
using MvcTurbine.Blades;

namespace MvcTurbine.NoRM
{
    public class NoRMBlade : Blade
    {
        public override void Spin(IRotorContext context)
        {
            var unityContainer = ((Unity.UnityServiceLocator)context.ServiceLocator).Container;

            unityContainer.RegisterType(typeof(IMongoRepositoryFactory), typeof(MongoRepositoryFactory));
            unityContainer.RegisterType(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            unityContainer.RegisterType(typeof(IMongoFactory), typeof(MongoFactory));
        }
    }
}