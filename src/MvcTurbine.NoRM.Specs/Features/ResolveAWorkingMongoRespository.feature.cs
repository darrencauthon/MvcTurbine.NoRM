// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.3.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace MvcTurbine.NoRM.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Resolve a working mongo repository")]
    public partial class ResolveAWorkingMongoRepositoryFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ResolveAWorkingMongoRespository.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Resolve a working mongo repository", "In order to work with mongo data\r\nAs a programmer\r\nI want to be able to resolve a" +
                    " working mongo repository from the many Turbine service locators", ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Resolve a class with a dependency on IMongoRepository<T> with Unity service locat" +
            "or")]
        public virtual void ResolveAClassWithADependencyOnIMongoRepositoryTWithUnityServiceLocator()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Resolve a class with a dependency on IMongoRepository<T> with Unity service locat" +
                    "or", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
testRunner.Given("a mongo db \'TEST\' on server \'localhost\' on port \'27017\'");
#line 8
testRunner.And("I have a Unity service locator");
#line 9
testRunner.And("I am referencing MvcTurbine.NoRM.Unity");
#line 10
testRunner.And("the NoRM registration has been completed");
#line 11
testRunner.And("I have spun the NoRM Blade");
#line 12
testRunner.When("I resolve a class with a dependency on IMongoRepositoryFactory");
#line 13
testRunner.And("I get a IMongoRepository<Account> class out of the factory");
#line 14
testRunner.Then("I should have received an instance of MongoRepository<Account>");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion
