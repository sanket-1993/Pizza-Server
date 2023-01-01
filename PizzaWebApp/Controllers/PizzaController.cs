using System.Web.Http;
using NLog;
using Contract;
using System.Web.Http.Cors;
using System;

namespace PizzaWebApp.Controllers
{
    //i[Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //[WebApiOutputCache(120, 60, false)]
    //[Throttle(Name = "TestThrottle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 5)]
    [RoutePrefix("api/pizza")]
    public class PizzaController : ApiController
    {
        private IPizzaService PizzaService;
        public PizzaController(IPizzaService _pizzaService)
        {
            this.PizzaService = _pizzaService;
        }

        Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get All pizzas from the system
        /// </summary>
        /// <returns>List<Pizza></returns>
        [HttpGet]
        [Route("getPizza")]
        //[WebApiOutputCache(120, 60, false)]
        //[Throttle(Name = "TestThrottle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 5)]
        public IHttpActionResult GetPizza()
        {
            try
            {
                logger.Info("Inside pizza/getPizza");
                var result = this.PizzaService.GetPizza();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Error("Exception in pizza/getPizza: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                return InternalServerError();
            }
            
        }

        /// <summary>
        /// Get toppings from system
        /// </summary>
        /// <returns>Collection of ingerdients</returns>
        [HttpGet]
        [Route("getToppings")]
        public IHttpActionResult GetToppings()
        {
            try
            {
                logger.Info("Inside pizza/gettoppings");
                var result = this.PizzaService.GetToppings();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Error("Exception in order/getToppings: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                return InternalServerError();
            }
            
        }

        /// <summary>
        /// Get specifc pizza from system
        /// </summary>
        /// <param name="pizzaId">PizzaId</param>
        /// <returns>Pizza</returns>
        [HttpGet]
        [Route("getSpecificPizza/{pizzaId}")]
        public IHttpActionResult GetSpecificPizza(int pizzaId)
        {
            try
            {
                logger.Info("Inside pizza/getSpecificPizza");
                var result = this.PizzaService.GetPizzaByID(pizzaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Error("Exception in pizza/getSpecificPizza: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                return InternalServerError();
            }
            
        }


        /// <summary>
        /// Get Size and crust 
        /// </summary>
        /// <param name="pizzaId">pizzaId</param>
        /// <returns>DataForDisplay</returns>
        [HttpGet]
        [Route("getSizeAndCrust/{pizzaId}")]
        public IHttpActionResult getSizeAndCrust(int pizzaId)
        {
            try
            {
                logger.Info("Inside pizza/getSizeAndCrust");
                var result = this.PizzaService.GetSizeAndCrust(pizzaId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Error("Exception in piza/getSizeAndCrust: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                return InternalServerError();
            }
            
        }

    }
}
