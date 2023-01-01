using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface INonPizzaService
    {
        List<NonPizza> GetNonPizzaItems();
        NonPizza GetNonPizzaByID(int ID);
    }
}
