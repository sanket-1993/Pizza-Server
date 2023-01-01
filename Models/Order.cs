using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        public int ID { get; set; }
        public Pizza Pizza { get; set; }
        public NonPizza NonPizza { get; set; }
        public int UserId { get; set; }
        public bool IsExtraCheese { get; set; }
        public int Quantity { get; set; }
    }
}
