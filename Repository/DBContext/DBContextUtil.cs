using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Repository
{
    public static class PizzaContext
    {
        public static double ExtraCheeseRate = 55;

        public static List<Pizza> GetPizza()
        {
            List<Pizza> result = new List<Pizza>();
            List<CrustSizeMapping> data = GetSizeAndCrust().CrustSizeMapping;
            Pizza pizza = new Pizza()
            {
                ID = 1,
                Name = "Margherita",
                Description = "Classic delight with 100% real mozzarella cheese",
                ImagePath = @"assets\Pizza\1.png",
                CrustSizeMapping = data.Count > 0 ? data.Where(p => p.PizzaID == 1).FirstOrDefault() : null,
                Offer = GetOffer()
            };
            result.Add(pizza);
            Pizza pizza2 = new Pizza()
            {
                ID = 2,
                Name = "Farmhouse",
                Description = "Delightful combination of onion, capsicum, tomato & grilled mushroom",
                ImagePath = @"assets\Pizza\2.png",
                CrustSizeMapping = data.Count > 0 ? data.Where(p => p.PizzaID == 2).FirstOrDefault() : null
            };
            result.Add(pizza2);
            Pizza pizza3 = new Pizza()
            {
                ID = 3,
                Name = "Pepper Barbecue Chicken",
                Description = "Pepper barbecue chicken for that extra zing",
                ImagePath = @"assets\Pizza\3.png",
                CrustSizeMapping = data.Count > 0 ? data.Where(p => p.PizzaID == 3).FirstOrDefault() : null

            };
            result.Add(pizza3);
            Pizza pizza4 = new Pizza()
            {
                ID = 4,
                Name = "Chicken Sausage",
                Description = "American classic! Spicy, herbed chicken sausage on pizza",
                ImagePath = @"assets\Pizza\4.png",
                CrustSizeMapping = data.Count > 0 ? data.Where(p => p.PizzaID == 4).FirstOrDefault() : null,
                Offer = GetOffer()
            };
            result.Add(pizza4);
            return result;
        }

        public static DataForDisplay GetSizeAndCrust()
        {

            DataForDisplay result = new DataForDisplay();
            result.ExtraCheeseRate = ExtraCheeseRate;

            result.Size = GetSizes();
            result.Crust = GetCrusts();
            result.CrustSizeMapping = GetCrustSizeMappings();
            return result;
        }

        public static List<Size> GetSizes()
        {
            List<Size> size = new List<Size>();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("PizzaWebApp", "Repository");
            if (File.Exists(path + @"\DBContext\" + "size.json"))
            {
                string Json = File.ReadAllText(path + @"\DBContext\" + "size.json");
                size = JsonConvert.DeserializeObject<List<Size>>(Json);
            }

            return size;
        }

        public static List<Crust> GetCrusts()
        {
            List<Crust> crusts = new List<Crust>();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("PizzaWebApp", "Repository");
            if (File.Exists(path + @"\DBContext\" + "crust.json"))
            {
                string Json = File.ReadAllText(path + @"\DBContext\" + "crust.json");
                crusts = JsonConvert.DeserializeObject<List<Crust>>(Json);
            }

            return crusts;
        }

        public static List<CrustSizeMapping> GetCrustSizeMappings()
        {
            List<CrustSizeMapping> crustSizeMappings = new List<CrustSizeMapping>();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("PizzaWebApp", "Repository");
            if (File.Exists(path + @"\DBContext\" + "crustSizeMapping.json"))
            {
                string Json = File.ReadAllText(path + @"\DBContext\" + "crustSizeMapping.json");
                crustSizeMappings = JsonConvert.DeserializeObject<List<CrustSizeMapping>>(Json);
            }
            return crustSizeMappings;
        }

        public static List<Ingredients> GetIngredients()
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("PizzaWebApp", "Repository");
            if (File.Exists(path + @"\DBContext\" + "ingredients.json"))
            {
                string Json = File.ReadAllText(path + @"\DBContext\" + "ingredients.json");
                ingredients = JsonConvert.DeserializeObject<List<Ingredients>>(Json);
            }
            return ingredients;
        }
        public static Offer GetOffer()
        {
            Offer offer = new Offer();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("PizzaWebApp", "Repository");
            if (File.Exists(path + @"\DBContext\" + "offer.json"))
            {
                string Json = File.ReadAllText(path + @"\DBContext\" + "offer.json");
                offer = JsonConvert.DeserializeObject<Offer>(Json);
            }
            return offer;
        }

        public static List<Ingredients> GetToppings()
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("PizzaWebApp", "Repository");
            if (File.Exists(path + @"\DBContext\" + "ingredients.json"))
            {
                string Json = File.ReadAllText(path + @"\DBContext\" + "ingredients.json");
                ingredients = JsonConvert.DeserializeObject<List<Ingredients>>(Json);
            }
            return ingredients;
        }
    }

    public static class UserContext
    {

    }

    public static class NonPizzaContext
    {
        public static List<NonPizza> GetNonPizza()
        {
            List<NonPizza> nonPizzas = new List<NonPizza>();
            NonPizza nonPizza = new NonPizza()
            {
                ID = 5,
                NonPizzaPrice = 60,
                Name = "Pepsi (500ml)",
                Description = "Sparkling and Refreshing Beverage",
                ImagePath = @"assets\NonPizza\1.png",

            };

            NonPizza nonPizza1 = new NonPizza()
            {
                ID = 6,
                NonPizzaPrice = 60,
                Name = "Mirinda (500ml)",
                Description = "Delicious Orange Flavoured beverage",
                ImagePath = @"assets\NonPizza\2.png",
            };
            nonPizzas.Add(nonPizza);
            nonPizzas.Add(nonPizza1);
            return nonPizzas;
        }
    }
}
