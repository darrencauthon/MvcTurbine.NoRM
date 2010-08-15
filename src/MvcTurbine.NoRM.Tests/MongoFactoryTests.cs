using AutoMoq;
using NUnit.Framework;
using Should;

namespace MvcTurbine.NoRM.Tests
{
    [TestFixture]
    public class MongoFactoryTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void CreateMongo_returns_a_new_Mongo()
        {
            mocker.GetMock<IMongoConnectionSettingsRetriever>()
                .Setup(x => x.GetSettings())
                .Returns(new MongoConnectionSettings
                             {
                                 DatabaseName = "x",
                                 Server = "localhost",
                                 Port = "27017"
                             });

            var factory = mocker.Resolve<MongoFactory>();
            var result = factory.CreateMongo();

            result.ShouldNotBeNull();

            result.Database.DatabaseName.ShouldEqual("x");
        }
    }
}