using AutoMoq;
using Moq;
using MvcTurbine.NoRM.Mongo;
using Norm;
using Norm.Collections;
using NUnit.Framework;
using Should;

namespace MvcTurbine.NoRM.Tests.Mongo
{
    [TestFixture]
    public class MongoCollectionBuilderTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();

            mocker.GetMock<IMongoFactory>()
                .Setup(x => x.CreateMongo())
                .Returns(mocker.GetMock<IMongo>().Object);
        }

        [Test]
        public void Returns_the_mongo_collection_from_the_mongo_object()
        {
            var expected = new Mock<IMongoCollection<Sample>>().Object;

            mocker.GetMock<IMongo>()
                .Setup(x => x.GetCollection<Sample>())
                .Returns(expected);

            var builder = mocker.Resolve<MongoCollectionBuilder>();
            var result = builder.GetCollection<Sample>();
            result.ShouldBeSameAs(expected);
        }
    }
}