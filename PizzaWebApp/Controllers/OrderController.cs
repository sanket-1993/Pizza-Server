using System;
using System.Web.Http;
using System.Web.Http.Cors;
using Contract;
using Models;
using NLog;

namespace PizzaWebApp.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/order")]
    //[Throttle(Name = "TestThrottle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 5)]
    public class OrderController : ApiController
    {
        private IOrderService OrderService;
        public OrderController(IOrderService _orderService)
        {
            this.OrderService = _orderService;
        }

        Logger logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Places Order according to input object
        /// </summary>
        /// <param name="order">Order</param>
        /// <returns>result</returns>
        [Route("placeOrder")]
        [HttpPost]
        public IHttpActionResult Save(Order order)
        {
            var result = 0;
            try
            {
                logger.Info("Inside order/placeOrder");
                result = OrderService.PlaceOrder(order);
                return Ok(result);

            }
            catch (Exception ex)
            {
                logger.Error("Exception in order/placeOrder: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                return InternalServerError();
            }
            

        }
    }
}
