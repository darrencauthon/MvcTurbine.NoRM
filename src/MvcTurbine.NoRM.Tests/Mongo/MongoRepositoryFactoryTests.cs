using AutoMoq;
using MvcTurbine.NoRM.Mongo;
using NUnit.Framework;
using Should;

namespace MvcTurbine.NoRM.Tests.Mongo
{
    [TestFixture]
    public class MongoRepositoryFactoryTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void GetRepository_returns_a_repository()
        {
            var factory = mocker.Resolve<MongoRepositoryFactory>();
            var repository = factory.GetRepository();

            repository.ShouldNotBeNull();
            repository.ShouldBeType(typeof (MongoRepository));
        }
    }
}