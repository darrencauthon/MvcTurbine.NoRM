using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using Moq;
using Norm.Collections;
using NUnit.Framework;
using Should;

namespace MvcTurbine.NoRM.Tests
{
    [TestFixture]
    public class MongoRepositoryTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();

            mocker.GetMock<IMongoCollectionBuilder>()
                .Setup(x => x.GetCollection<Sample>())
                .Returns(mocker.GetMock<IMongoCollection<Sample>>().Object);
        }

        [Test]
        public void Retrieve_pulls_the_collection_from_the_generic_mongo_collection_builder()
        {
            var expected = new List<Sample>().AsQueryable();

            mocker.GetMock<IMongoCollectionBuilder>()
                .Setup(x => x.GetCollection<Sample>())
                .Returns(CreateMongoCollectionThatReturnsThisQueryable(expected));

            var repository = mocker.Resolve<MongoRepository>();
            var result = repository.Retrieve<Sample>();

            result.ShouldBeSameAs(expected);
        }

        [Test]
        public void Add_will_call_add_on_the_mongo_collection_from_the_builder()
        {
            var expected = new Sample();

            mocker.GetMock<IMongoCollection<Sample>>()
                .Setup(x => x.Insert(It.IsAny<IEnumerable<Sample>>()))
                .Callback((IEnumerable<Sample> s) =>
                              {
                                  s.Count().ShouldEqual(1);
                                  s.First().ShouldEqual(expected);
                              });

            var repository = mocker.Resolve<MongoRepository>();
            repository.Add(expected);

            mocker.GetMock<IMongoCollection<Sample>>()
                .Verify(x => x.Insert(It.IsAny<IEnumerable<Sample>>()), Times.Once());
        }

        [Test]
        public void Update_will_call_update_on_the_mongo_collection_from_the_builder()
        {
            var expected = new Sample();

            var repository = mocker.Resolve<MongoRepository>();
            repository.Update(expected);

            mocker.GetMock<IMongoCollection<Sample>>()
                .Verify(x => x.Save(expected), Times.Once());
        }

        [Test]
        public void Delete_will_call_delete_on_the_mongo_collection_from_the_builder()
        {
            var expected = new Sample();

            var repository = mocker.Resolve<MongoRepository>();
            repository.Delete(expected);

            mocker.GetMock<IMongoCollection<Sample>>()
                .Verify(x => x.Delete(expected), Times.Once());
        }

        private IMongoCollection<Sample> CreateMongoCollectionThatReturnsThisQueryable(IQueryable<Sample> expected)
        {
            var collection = mocker.GetMock<IMongoCollection<Sample>>();
            collection.Setup(x => x.AsQueryable())
                .Returns(expected);
            return collection.Object;
        }
    }

    public class Sample
    {
    }
}