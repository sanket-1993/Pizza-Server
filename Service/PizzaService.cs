using Models;
using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Repository
{
    public class PizzaService: IPizzaService
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        public List<Pizza> GetPizza()
        {
            logger.Info("Inside PizzaService/GetPizza");
            try
            {
                return PizzaContext.GetPizza();

            }
            catch (Exception ex)
            {
                logger.Error("Exception in Pizza/GetPizza: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                throw ex;
            }
        }

        public List<Ingredients> GetToppings()
        {
            logger.Info("Inside PizzaService/GetToppings");

            try
            {
                return PizzaContext.GetToppings();
            }
            catch (Exception ex)
            {
                logger.Error("Exception in Pizza/GetToppings: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                throw ex;
            }
        }

        public Pizza GetPizzaByID(int ID)
        {
            logger.Info("Inside PizzaService/GetPizzaByID/{0}",ID);
            try
            {
                return PizzaContext.GetPizza().Where(p => p.ID == ID).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Error("Exception in Pizza/GetPizzaByID: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                throw ex;
            }
        }

        public DataForDisplay GetSizeAndCrust(int ID)
        {
            logger.Info("Inside PizzaService/GetSizeAndCrust/{0}", ID);
            try
            {
                DataForDisplay result = PizzaContext.GetSizeAndCrust();
                if (result != null)
                {
                    result.CrustSizeMapping = result.CrustSizeMapping.Where(p => p.PizzaID == ID).ToList();
                }
                return result;
            }
            catch (Exception ex)
            {
                logger.Error("Exception in Pizza/GetSizeAndCrust: {0} \r\n {1}", ex.ToString(), ex.StackTrace);
                throw ex;
            }
            
        }
    }
}
