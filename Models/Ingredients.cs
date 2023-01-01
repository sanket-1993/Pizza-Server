using System.ComponentModel.DataAnnotations;


namespace Models
{
    public class Ingredients
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public ToppingType ToppingType { get; set; }

    }



    public enum ToppingType
    {
        [Display(Name = "Veg Topping")]
        Veg = 1,
        [Display(Name = "Non-Veg Topping")]
        NonVeg = 2

    }
}
