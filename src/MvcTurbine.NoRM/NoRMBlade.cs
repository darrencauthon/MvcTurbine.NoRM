using System.Collections.Generic;
using System.Linq;
using MvcTurbine.Blades;
using MvcTurbine.ComponentModel;

namespace MvcTurbine.NoRM
{
    public class NoRMBlade : Blade, ISupportAutoRegistration
    {
        public override void Spin(IRotorContext context)
        {
            var serviceLocator = context.ServiceLocator;
            GetNoRMSetupServies(serviceLocator)
                .First(setup => setup.CanSetup(serviceLocator))
                .Setup(serviceLocator);
        }

        private static IList<ISetupNoRM> GetNoRMSetupServies(IServiceLocator serviceLocator)
        {
            return serviceLocator.ResolveServices<ISetupNoRM>();
        }

        public void AddRegistrations(AutoRegistrationList registrationList)
        {
            registrationList.Add(Registration.Simple<ISetupNoRM>());
        }
    }
}