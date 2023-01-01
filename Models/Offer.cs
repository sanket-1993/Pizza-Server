using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Offer
    {
        public int ID { get; set; }
        public Pizza Pizza { get; set; }
        public double OfferInPercentage { get; set; }
    }
}
