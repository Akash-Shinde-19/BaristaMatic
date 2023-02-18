using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaMatic.Models
{
    /// <summary>
    /// Recipe class
    /// </summary>
    public class Recipe
    {
        /// <summary>
        /// Name of drink or recipe
        /// </summary>
        private readonly string name;

        /// <summary>
        /// Dictionary to store the ingredients required to make drink
        /// </summary>
        private readonly SortedDictionary<string, int> ingredients;

        /// <summary>
        /// Main inventory
        /// </summary>
        private readonly Inventory inventory;

        public Recipe(string name, Inventory inventory)
        {
            this.name = name;
            this.inventory = inventory;
            ingredients = new SortedDictionary<string, int>();
        }

        public string Name { get { return name; } }

        /// <summary>
        /// Add ingredient to drink recipe
        /// </summary>
        /// <param name="name">Name of ingredient</param>
        /// <param name="qty">Quantity ingredient</param>
        public void AddIngredient(string name, int qty)
        {
            ingredients.Add(name, qty);
        }

        /// <summary>
        /// Calculate cost of drink
        /// </summary>
        /// <returns>Cost of drink</returns>
        public double GetCost()
        {
            double cost = 0;
            foreach (KeyValuePair<string, int> entry in ingredients)
            {
                Ingredient ing = inventory.GetIngredient(entry.Key);
                cost += ing.Cost * entry.Value;
            }
            cost = Math.Round(cost, 2);
            return cost;
        }

        /// <summary>
        /// Checks whether ingredient is in stock or not
        /// </summary>
        /// <returns>True/False</returns>
        public bool IsAvailable()
        {
            bool available = true;
            foreach (KeyValuePair<string, int> entry in ingredients)
            {
                if (!inventory.IsAvailable(entry.Key, entry.Value))
                {
                    available = false;
                    break;
                }
            }
            return available;
        }

        /// <summary>
        /// Dispense the drink
        /// </summary>
        public void MakeDrink()
        {
            if (IsAvailable())
            {
                Console.WriteLine(string.Format("Dispensing: {0}", name));
                foreach (KeyValuePair<string, int> entry in ingredients)
                {
                    inventory.DispenseIngredient(entry.Key, entry.Value);
                }
            }
            else
            {
                Console.WriteLine(string.Format("Out of stock:: {0}", name));
            }
        }
    }

    /// <summary>
    /// CoffeeRecipe
    /// </summary>
    public class CoffeeRecipe : Recipe
    {
        public CoffeeRecipe(Inventory inventory) : base(DrinkType.Coffee, inventory)
        {
            AddIngredient(IngredientType.Coffee, 3);
            AddIngredient(IngredientType.Sugar, 1);
            AddIngredient(IngredientType.Cream, 1);
        }
    }

    /// <summary>
    /// DecafCoffeeRecipe
    /// </summary>
    public class DecafCoffeeRecipe : Recipe
    {
        public DecafCoffeeRecipe(Inventory inventory) : base(DrinkType.DecafCoffee, inventory)
        {
            AddIngredient(IngredientType.DecafCoffee, 3);
            AddIngredient(IngredientType.Sugar, 1);
            AddIngredient(IngredientType.Cream, 1);
        }
    }

    /// <summary>
    /// CaffeLatteRecipe
    /// </summary>
    public class CaffeLatteRecipe : Recipe
    {
        public CaffeLatteRecipe(Inventory inventory) : base(DrinkType.CaffeLatte, inventory)
        {
            AddIngredient(IngredientType.Espresso, 2);
            AddIngredient(IngredientType.SteamedMilk, 1);
        }
    }

    /// <summary>
    /// CaffeAmericanoRecipe
    /// </summary>
    public class CaffeAmericanoRecipe : Recipe
    {
        public CaffeAmericanoRecipe(Inventory inventory) : base(DrinkType.CaffeAmericano, inventory)
        {
            AddIngredient(IngredientType.Espresso, 3);
        }
    }

    /// <summary>
    /// CaffeMochaRecipe
    /// </summary>
    public class CaffeMochaRecipe : Recipe
    {
        public CaffeMochaRecipe(Inventory inventory) : base(DrinkType.CaffeMocha, inventory)
        {
            AddIngredient(IngredientType.Espresso, 1);
            AddIngredient(IngredientType.Cocoa, 1);
            AddIngredient(IngredientType.SteamedMilk, 1);
            AddIngredient(IngredientType.WhippedCream, 1);
        }
    }

    /// <summary>
    /// CappuccinoRecipe
    /// </summary>
    public class CappuccinoRecipe : Recipe
    {
        public CappuccinoRecipe(Inventory inventory) : base(DrinkType.Cappuccino, inventory)
        {
            AddIngredient(IngredientType.Espresso, 2);
            AddIngredient(IngredientType.SteamedMilk, 1);
            AddIngredient(IngredientType.FoamedMilk, 1);
        }
    }
}
