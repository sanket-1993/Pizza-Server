using Moq;
using NUnit.Framework;
using Repository;
using PizzaWebApp.Controllers;
using System.Web.Http.Results;
using Models;
using System.Linq;

namespace OrderServiceTest
{
    [Category("OrderService")]
    [TestFixture]
    class OrderControllerTest
    {
        private OrderController controller;

        [SetUp]
        public void Setup()
        {
            var mockRepository = new Mock<OrderService>();
            controller = new OrderController(mockRepository.Object);
        }

        [Test]
        public void SaveOrderTest()
        {
            Order order = new Order()
            {
                Quantity = 4,
                NonPizza = NonPizzaContext.GetNonPizza().Where(p => p.ID == 6).FirstOrDefault()
            };
            var result = controller.Save(order);
            int value = ((OkNegotiatedContentResult<int>)result).Content;
            Assert.AreNotEqual(value, 0,"Order has not been placed");
        }
    }
}
