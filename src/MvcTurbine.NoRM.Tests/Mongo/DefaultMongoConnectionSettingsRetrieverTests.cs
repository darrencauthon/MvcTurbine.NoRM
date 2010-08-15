using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMoq;
using MvcTurbine.NoRM.Db;
using NUnit.Framework;
using Should;

namespace MvcTurbine.NoRM.Tests.Mongo
{
    [TestFixture]
    public class DefaultMongoConnectionSettingsRetrieverTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void Returns_settings()
        {
            var retriever = mocker.Resolve<DefaultMongoConnectionSettingsRetriever>();
            var result = retriever.GetSettings();

            result.ShouldNotBeNull();
        }

        [Test]
        public void The_default_server_is_localhost()
        {
            var retriever = mocker.Resolve<DefaultMongoConnectionSettingsRetriever>();
            var result = retriever.GetSettings();

            result.Server.ShouldEqual("localhost");
        }

        [Test]
        public void The_default_port_is_27017()
        {
            var retriever = mocker.Resolve<DefaultMongoConnectionSettingsRetriever>();
            var result = retriever.GetSettings();

            result.Port.ShouldEqual("27017");
        }

        [Test]
        public void The_default_server_name_is_the_calculated_default_server_name()
        {
            mocker.GetMock<IDefaultServerNameCalculator>()
                .Setup(x => x.CalculateName())
                .Returns("EXPECTED");

            var retriever = mocker.Resolve<DefaultMongoConnectionSettingsRetriever>();
            var result = retriever.GetSettings();

            result.DatabaseName.ShouldEqual("EXPECTED");
        }
    }
}
