using Contract;
using NLog;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PizzaWebApp.Controllers
{
    [Authorize]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/nonPizza")]
    //[WebApiOutputCache(120, 60, false)]
    //[Throttle(Name = "TestThrottle", Message = "You must wait {n} seconds before accessing this url again.", Seconds = 5)]
    public class NonPizzaController : ApiController
    {
        private INonPizzaService NonPizzaService;
        public NonPizzaController(INonPizzaService _iNonPizzaService)
        {
            this.NonPizzaService = _iNonPizzaService;
        }

        static Logger logger = LogManager.GetCurrentClassLogger();


        /// <summary>
        /// Get non pizza items from database
        /// </summary>
        /// <returns>Collection of NonPizza items</returns>
        [Route("items")]
        [HttpGet]
        public IHttpActionResult GetNonPizza()
        {
            try
            {
                logger.Info("Inside nonPizza/item");
                var result = NonPizzaService.GetNonPizzaItems();
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Error("Exception in nonPizza/items: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                return InternalServerError();
            }
            
        }

        [Route("item/{itemId}")]
        [HttpGet]
        public IHttpActionResult GetNonPizzaByID(int itemId)
        {
            try
            {
                logger.Info("Inside nonPizza/item/{0}",itemId);
                var result = NonPizzaService.GetNonPizzaByID(itemId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.Error("Exception in nonPizza/items/{0}: {1} \r\n {2}", itemId ,ex.ToString(), ex.StackTrace);
                return InternalServerError();
            }
            
        }
    }
}
