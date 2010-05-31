using System.Collections.Generic;
using System.Linq;
using System.Text;
using Norm;
using SpecFlowAssist;
using TechTalk.SpecFlow;
using Should;

namespace MvcTurbine.NoRM.Specs.Steps
{
    [Binding]
    public class GenericMongoRepositorySteps
    {

        public ScenarioContext context { get { return ScenarioContext.Current; } }

        [Given(@"a mongo db '(.*)' on server '(.*)' on port '(.*)'")]
        public void GivenAMongoDbTESTOnServerLocalhostOnPort(string db, string server, string port)
        {
            var mongo = new Mongo(db, server, port, string.Empty);
            context.Set(mongo);
        }

        [Given(@"the '(.*)' collection has not been created")]
        public void GivenTheAccountCollectionHasNotBeenCreated(string collectionName)
        {
            var mongo = context.Get<Mongo>();
            mongo.Database.DropCollection("Account");
        }

        [When(@"I add an account object to the repository")]
        public void WhenIAddAnAccountObjectToTheRepository()
        {
            var mongo = context.Get<Mongo>();
            var collection = mongo.GetCollection<Account>();

            var repository = new MongoRepository<Account>(collection);
            repository.Add(new Account());
        }

        [Then(@"there should be (.*) object in the '(.*)' collection")]
        public void ThenThereShouldBe1ObjectInTheAccountCollection(int objectCount, string collectionName)
        {
            var mongo = context.Get<Mongo>();

            mongo.Database.GetCollection(collectionName).Count().ShouldEqual(objectCount);

        }

        private class Account { public System.Guid Id { get; set; } }
    }
}
