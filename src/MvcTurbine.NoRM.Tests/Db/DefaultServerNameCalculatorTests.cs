using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMoq;
using MvcTurbine.NoRM.Db;
using NUnit.Framework;
using Should;

namespace MvcTurbine.NoRM.Tests.Db
{
    [TestFixture]
    public class DefaultServerNameCalculatorTests
    {
        private AutoMoqer mocker;

        [SetUp]
        public void Setup()
        {
            mocker = new AutoMoqer();
        }

        [Test]
        public void Returns_the_name_when_there_are_no_periods()
        {
            mocker.GetMock<ICurrentAssemblyNameRetriever>()
                .Setup(x => x.GetName())
                .Returns("TestName");

            var calculator = mocker.Resolve<DefaultServerNameCalculator>();
            var name = calculator.CalculateName();

            name.ShouldEqual("TestName");

        }

        [Test]
        public void Replaces_periods_with_underscores_when_periods_exist()
        {
            mocker.GetMock<ICurrentAssemblyNameRetriever>()
                .Setup(x => x.GetName())
                .Returns("One.Two.Three");

            var calculator = mocker.Resolve<DefaultServerNameCalculator>();
            var name = calculator.CalculateName();

            name.ShouldEqual("One_Two_Three");            
        }
    }
}
