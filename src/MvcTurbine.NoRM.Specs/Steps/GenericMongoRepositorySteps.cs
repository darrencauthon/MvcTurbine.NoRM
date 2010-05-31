using System;
using System.Linq;
using Norm;
using Norm.Collections;
using NUnit.Framework;
using Should;
using SpecFlowAssist;
using TechTalk.SpecFlow;

namespace MvcTurbine.NoRM.Specs.Steps
{
    [Binding]
    public class GenericMongoRepositorySteps
    {
        private const string newAccountId = "new account id";

        public ScenarioContext context
        {
            get { return ScenarioContext.Current; }
        }

        [Given(@"a mongo db '(.*)' on server '(.*)' on port '(.*)'")]
        public void GivenAMongoDbTESTOnServerLocalhostOnPort(string db, string server, string port)
        {
            try
            {
                var mongo = new Mongo(db, server, port, string.Empty);
                context.Set(mongo);
            }
            catch
            {
                Assert.Inconclusive("Could not set up the mongo database");
            }
        }

        [Given(@"the '(.*)' collection has not been created")]
        public void GivenTheAccountCollectionHasNotBeenCreated(string collectionName)
        {
            var mongo = context.Get<Mongo>();
            mongo.Database.DropCollection("Account");
        }

        [Given(@"the '(.*)' collection exists")]
        public void GivenTheAccountCollectionExists(string collectionName)
        {
            var mongo = context.Get<Mongo>();
            mongo.Database.DropCollection(collectionName);
            mongo.Database.CreateCollection(new CreateCollectionOptions{Name = collectionName});
        }

        [Given(@"an account with id of X exists in the collection")]
        public void GivenAnAccountWithIdOfXExistsInTheCollection()
        {
            var mongo = context.Get<Mongo>();
            
            var newGuid = Guid.NewGuid();
            
            context["X"] = newGuid;

            mongo.GetCollection<Account>().Insert(new Account(){ Id = newGuid});
        }

        [When(@"I add an account object to the repository")]
        public void WhenIAddAnAccountObjectToTheRepository()
        {
            var mongo = context.Get<Mongo>();
            var collection = mongo.GetCollection<Account>();

            var repository = new MongoRepository<Account>(collection);
            repository.Add(new Account());
        }

        [When(@"I update the name of the account to '(.*)'")]
        public void WhenIUpdateTheNameOfTheAccountToChanged(string value)
        {
            var mongo = context.Get<Mongo>();
            var collection = mongo.GetCollection<Account>();

            var account = new Account{Id = (Guid)context["X"], Name = value };

            var repository = new MongoRepository<Account>(collection);
            repository.Update(account);
        }

        [When(@"I retrieve the accounts from the repository")]
        public void WhenIRetrieveTheAccountsFromTheRepository()
        {
            var mongo = context.Get<Mongo>();
            var collection = mongo.GetCollection<Account>();

            var repository = new MongoRepository<Account>(collection);
            var accounts = repository.Retrieve();

            context.Set(accounts);
        }

        [When(@"I delete the account with X")]
        public void WhenIDeleteTheAccountWithX()
        {
            var mongo = context.Get<Mongo>();
            var collection = mongo.GetCollection<Account>();

            var id = (Guid)context["X"];

            var repository = new MongoRepository<Account>(collection);
            var account = repository.Retrieve().Where(x=>x.Id == id).Single();

            repository.Delete(account);
        }

        [Then(@"there should be (.*) object in the '(.*)' collection")]
        public void ThenThereShouldBe1ObjectInTheAccountCollection(int objectCount, string collectionName)
        {
            var mongo = context.Get<Mongo>();

            mongo.Database.GetCollection(collectionName).Count().ShouldEqual(objectCount);
        }

        [Then(@"the account document with id of X has a name of '(.*)'")]
        public void ThenTheAccountDocumentWithIdOfXHasANameOfChanged(string value)
        {

            var id = (Guid)context["X"];

            var mongo = context.Get<Mongo>();
            var account = mongo.GetCollection<Account>().Find().Where(x => x.Id == id).First();

            account.Name.ShouldEqual(value);

        }

        [Then(@"the account document with an id of X was returned")]
        public void ThenTheAccountdocumentWithAnIdOfXWasReturned()
        {
            var id = (Guid)context["X"];

            var accounts = context.Get<IQueryable<Account>>();

            accounts.Where(x => x.Id == id).First().ShouldNotBeNull();
        }

        [Then(@"the account document with an id of X no longer exists in the collection")]
        public void ThenTheAccountDocumentWithAnIdOfXNoLongerExistsInTheCollection()
        {
            var id = (Guid)context["X"];

            var mongo = context.Get<Mongo>();
            var account = mongo.GetCollection<Account>().Find().Where(x => x.Id == id).FirstOrDefault();

            account.ShouldBeNull();
        }

        private class Account
        {
            public Guid Id { get; set; }

            public string Name { get; set; }
        }
    }
}