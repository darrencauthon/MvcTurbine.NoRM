using System.Web;
using MvcTurbine.ComponentModel;
using MvcTurbine.NoRM.Mongo;

namespace MvcTurbine.NoRM.HttpHandlers
{
    public class SessionHttpHandler : IHttpModule
    {
        private readonly IServiceLocator serviceLocator;

        public SessionHttpHandler(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest +=
                (sender, e) =>
                    {
                        HttpContext.Current.Items["MongoFactory"] = serviceLocator.Resolve<IMongoRepositoryFactory>();
                    };

            context.EndRequest +=
                (sender, e) =>
                    {
                        var mongoFactory = HttpContext.Current.Items["MongoFactory"] as MongoRepositoryFactory;
                        mongoFactory.Dispose();
                        HttpContext.Current.Items["MongoFactory"] = null;
                    };
        }

        public void Dispose()
        {
        }
    }
}