using Moq;
using MvcTurbine.ComponentModel;
using MvcTurbine.NoRM.Unity;
using MvcTurbine.Unity;
using Should;
using SpecFlowAssist;
using TechTalk.SpecFlow;

namespace MvcTurbine.NoRM.Specs.Steps
{
    [Binding]
    public class ResolveAWorkingMongoRepositorySteps
    {
        public ScenarioContext context
        {
            get { return ScenarioContext.Current; }
        }

        [Given(@"I have a Unity service locator")]
        public void GivenIHaveAUnityServiceLocator()
        {
            context.Set<IServiceLocator>(new UnityServiceLocator());
        }

        [Given(@"the NoRM registration has been completed")]
        public void GivenTheNoRMRegistrationHasBeenCompleted()
        {
            var autoRegistrationList = new AutoRegistrationList();

            var blade = GetTheNoRMBlade();
            blade.AddRegistrations(autoRegistrationList);

            var autoRegistrator = new DefaultAutoRegistrator(context.Get<IServiceLocator>());
            using (context.Get<IServiceLocator>().Batch())
                foreach (var registration in autoRegistrationList)
                    autoRegistrator.AutoRegister(registration);
        }

        [Given(@"I have spun the NoRM Blade")]
        public void GivenIHaveSpunTheNoRMBlade()
        {
            var rotorContextFake = new Mock<IRotorContext>();
            rotorContextFake.Setup(x => x.ServiceLocator)
                .Returns(context.Get<IServiceLocator>());

            var normBlade = GetTheNoRMBlade();
            normBlade.Spin(rotorContextFake.Object);
        }

        [Given(@"I am referencing MvcTurbine\.NoRM\.Unity")]
        public void GivenIAmReferencingMvcTurbine_NoRM_Unity()
        {
            var testingType = typeof(SetupNoRMWithUnity);
        }

        private NoRMBlade GetTheNoRMBlade()
        {
            var blade = new NoRMBlade();
            if (context.ContainsKey("NoRMBlade") == false)
                context["NoRMBlade"] = new NoRMBlade();
            return context["NoRMBlade"] as NoRMBlade;
        }

        [When(@"I resolve a class with a dependency on IMongoRepositoryFactory")]
        public void WhenIResolveAClassWithADependencyOnIMongoRepositoryAccount()
        {
            var serviceLocator = context.Get<IServiceLocator>();

            var repository = serviceLocator.Resolve<IMongoRepositoryFactory>();

            context.Set(repository);
        }

        [When(@"I get a IMongoRepository<Account> class out of the factory")]
        public void WhenIGetAIMongoRepositoryAccountClassOutOfTheFactory()
        {
            var factory = context.Get<IMongoRepositoryFactory>();

            using (var repo = factory.GetRepository<Account>())
                context.Set(repo.GetType() == typeof (MongoRepository<Account>), "Account repository was returned");

            context.Set(factory);
        }

        [Then(@"I should have received an instance of MongoRepository<Account>")]
        public void ThenTheClassShouldReceiveAnInstanceOfMongoRepositoryAccount()
        {
            var receivedInstance = (bool) context["Account repository was returned"];

            receivedInstance.ShouldBeTrue();
        }
    }

    public class Account
    {
    }
}