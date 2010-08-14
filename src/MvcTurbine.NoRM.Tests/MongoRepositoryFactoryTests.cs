using AutoMoq;
using NUnit.Framework;

namespace MvcTurbine.NoRM.Tests
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
        public void GetRepository_returns_a_repository_of_type_T()
        {
            Assert.Fail("START HERE");
        }
    }
}