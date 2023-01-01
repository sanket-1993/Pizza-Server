using Contract;
using Models;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Repository
{
    public class NonPizzaService: INonPizzaService
    {
        static Logger logger = LogManager.GetCurrentClassLogger();

        public List<NonPizza> GetNonPizzaItems()
        {
            logger.Info("inside NonPizzaService/GetNonPizzaItems");

            try
            {
                List<NonPizza> nonPizzas = new List<NonPizza>();
                nonPizzas = NonPizzaContext.GetNonPizza();

                return nonPizzas;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public NonPizza GetNonPizzaByID(int ID)
        {
            logger.Info("inside NonPizzaService/GetNonPizzaByID/{0}",ID);

            try
            {
                NonPizza nonPizza = new NonPizza();
                nonPizza = NonPizzaContext.GetNonPizza().Where(p => p.ID == ID).FirstOrDefault();
                return nonPizza;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
