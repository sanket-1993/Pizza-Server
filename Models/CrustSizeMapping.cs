using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Crust
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<CrustSizeMapping> CrustMapping { get; set; }
    }
    public class CrustSizeMapping
    {
        public int CrustSizeMappingID { get; set; }
        public int PizzaID { get; set; }
        public Size Size { get; set; }
        public Crust Crust { get; set; }
        public double Price { get; set; }

    }

    public class Size
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<CrustSizeMapping> SizeMapping { get; set; }

    }
    public class DataForDisplay
    {
        public List<Size> Size { get; set; }
        public List<Crust> Crust { get; set; }
        public List<CrustSizeMapping> CrustSizeMapping { get; set; }
        public double ExtraCheeseRate { get; set; }
    }
}
