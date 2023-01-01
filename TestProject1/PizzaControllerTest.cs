using System.Collections.Generic;
using System.Web.Http.Results;
using Models;
using Moq;
using NUnit.Framework;
using Repository;
using PizzaWebApp.Controllers;
using System.Linq;

namespace PizzaServiceTest
{
    [Category("PizzaService")]
    [TestFixture]
    public class PizzaControllerTest
    {
        private PizzaController controller;
        [SetUp]
        public void Setup()
        {
            var mockRepository = new Mock<PizzaService>();
            controller = new PizzaController(mockRepository.Object);
        }

        [Test]
        public void GetPizzaTest()
        {
            var pizzas = controller.GetPizza();
            var value = ((OkNegotiatedContentResult<List<Pizza>>)pizzas).Content;
            var dbRecords = PizzaContext.GetPizza().Count;
            Assert.AreEqual(value.Count,dbRecords,"Count mismatch in Pizza List");
            
        }

        [Test]
        public void GetToppingsTest()
        {
            var toppings = controller.GetToppings();
            var value = ((OkNegotiatedContentResult<List<Ingredients>>)toppings).Content;
            var dbRecords = PizzaContext.GetToppings();
            Assert.AreEqual(value.Count, dbRecords.Count, "Count mismatch in Toppings List");
        }

        [Test]
        public void GetSpecificPizzaTest()
        {
            var pizza = controller.GetSpecificPizza(1);
            var value = ((OkNegotiatedContentResult<Pizza>)pizza).Content;
            var dbRecords = PizzaContext.GetPizza().Where(p => p.ID == 1).FirstOrDefault();
            Assert.AreEqual(value.Price, dbRecords.Price, "Mismatched record from controller");
        }

        [Test]
        public void GetSizeAndCrustTest()
        {
            var sizeandcrust = controller.getSizeAndCrust(1);
            var value = ((OkNegotiatedContentResult<DataForDisplay>)sizeandcrust).Content;
            var dbRecords = PizzaContext.GetSizeAndCrust().CrustSizeMapping.Where(p => p.PizzaID == 1).ToList();
            Assert.AreEqual(value.CrustSizeMapping.Count, dbRecords.Count, "Mismatched record from controller");
        }
    }
}