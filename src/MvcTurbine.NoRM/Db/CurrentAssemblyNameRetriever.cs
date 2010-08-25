using System;
using System.Linq;
using MvcTurbine.Web;

namespace MvcTurbine.NoRM.Db
{
    public interface ICurrentAssemblyNameRetriever
    {
        string GetName();
    }

    public class CurrentAssemblyNameRetriever : ICurrentAssemblyNameRetriever
    {
        public string GetName()
        {
            var fullName = AppDomain.CurrentDomain.GetAssemblies()
                .Select(x => x.GetTypes()
                                 .FirstOrDefault(type => type.BaseType == typeof (TurbineApplication)))
                .Where(x => x != null)
                .First()
                .FullName;
            return (fullName.Split(',')[0] + '.').Split('.')[0];
        }
    }
}