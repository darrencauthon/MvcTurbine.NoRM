using Microsoft.Practices.Unity;
using MvcTurbine.ComponentModel;
using UnityServiceLocator = MvcTurbine.Unity.UnityServiceLocator;

namespace MvcTurbine.NoRM.Unity
{
    public class SetupNoRMWithUnity : ISetupNoRM
    {
        public bool CanSetup(IServiceLocator serviceLocator)
        {
            return serviceLocator.GetType() == typeof (UnityServiceLocator);
        }

        public void Setup(IServiceLocator serviceLocator)
        {
            var unityContainer = serviceLocator.GetUnderlyingContainer<IUnityContainer>();

            unityContainer.RegisterType(typeof (IMongoRepositoryFactory), typeof (MongoRepositoryFactory));
            unityContainer.RegisterType(typeof (IMongoRepository<>), typeof (MongoRepository<>));
            unityContainer.RegisterType(typeof (IMongoFactory), typeof (MongoFactory));
        }
    }
}