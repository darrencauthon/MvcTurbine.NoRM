using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMoq;
using NUnit.Framework;

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
            var mongoFactory = mocker.Resolve<MongoFactory>();
        }
    }

    public class MongoFactory
    {
    }
}
