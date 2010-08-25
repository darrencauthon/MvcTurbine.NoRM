namespace MvcTurbine.NoRM.Db
{
    public interface IDefaultServerNameCalculator
    {
        string CalculateName();
    }

    public class DefaultServerNameCalculator : IDefaultServerNameCalculator
    {
        private readonly ICurrentAssemblyNameRetriever currentAssemblyNameRetriever;

        public DefaultServerNameCalculator(ICurrentAssemblyNameRetriever currentAssemblyNameRetriever)
        {
            this.currentAssemblyNameRetriever = currentAssemblyNameRetriever;
        }

        public string CalculateName()
        {
            return currentAssemblyNameRetriever.GetName()
                .Replace(".", "_");
        }
    }
}