using MvcTurbine.ComponentModel;

namespace MvcTurbine.NoRM
{
    public interface ISetupNoRM
    {
        bool CanSetup(IServiceLocator serviceLocator);
        void Setup(IServiceLocator serviceLocator);
    }
}