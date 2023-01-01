using System.Collections.Generic;
using Models;

namespace Contract
{
    public interface IPizzaService
    {
        List<Pizza> GetPizza();
        List<Ingredients> GetToppings();
        Pizza GetPizzaByID(int ID);
        DataForDisplay GetSizeAndCrust(int ID);
    }
}
