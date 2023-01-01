using Contract;
using Models;
using Moq;
using NUnit.Framework;
using PizzaWebApp.Controllers;
using Repository;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace NonPizzaServiceTest
{
    [Category("NonPizzaService")]
    [TestFixture]
    class NonPizzaControllerTest
    {
        private NonPizzaController controller;

        [SetUp]
        public void Setup()
        {
            var mockRepository = new Mock<NonPizzaService>();
            controller = new NonPizzaController(mockRepository.Object);
        }

        [Test]
        public void GetNonPizzaTest()
        {
            var nonPizzas = controller.GetNonPizza();
            var value = ((OkNegotiatedContentResult<List<NonPizza>>)nonPizzas).Content;
            var dbRecords = NonPizzaContext.GetNonPizza().Count;
            Assert.AreEqual(value.Count, dbRecords, "Count mismatch in Non Pizza List");
        }

        [Test]
        public void GetNonPizzaByIDTest()
        {
            var nonPizzas = controller.GetNonPizzaByID(5);
            var value = ((OkNegotiatedContentResult<NonPizza>)nonPizzas).Content;
            var dbRecords = NonPizzaContext.GetNonPizza().Where(p => p.ID == 5).FirstOrDefault(); ;
            Assert.AreEqual(value.Name, dbRecords.Name, "Name mismatch in Non Pizza record returned by controller");

        }
    }
}
