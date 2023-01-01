using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pizza : Product
    {
        public List<Ingredients> Toppings { get; set; }
        public CrustSizeMapping CrustSizeMapping { get; set; }
        public double Price { get; set; }
        public Offer Offer { get; set; }
    }
}
