using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BaristaMatic.Models
{
    /// <summary>
    /// Inventory class
    /// </summary>
    public class Inventory
    {
        /// <summary>
        /// Dictionary to save all ingredient object list
        /// </summary>
        private SortedDictionary<string, Ingredient> Ingredients { get; set; }

        /// <summary>
        /// Dictionary to save available quantity of all ingredients
        /// </summary>
        private SortedDictionary<string, int> IngredientsQty { get; set; }

        /// <summary>
        /// MAX_QUANTITY of ingredient in inventory
        /// </summary>
        private const int MAX_QUANTITY = 10;
        
        public Inventory()
        {
            // Add Ingredients
            Ingredients = new SortedDictionary<string, Ingredient>
            {
                { IngredientType.Coffee, new Coffee() },
                { IngredientType.DecafCoffee, new DecafCoffee() },
                { IngredientType.Sugar, new Sugar() },
                { IngredientType.Cream, new Cream() },
                { IngredientType.SteamedMilk, new SteamedMilk() },
                { IngredientType.FoamedMilk, new FoamedMilk() },
                { IngredientType.Espresso, new Espresso() },
                { IngredientType.Cocoa, new Cocoa() },
                { IngredientType.WhippedCream, new WhippedCream() },
            };

            // Add Ingredient Quantities
            IngredientsQty = new SortedDictionary<string, int>
            {
                { IngredientType.Coffee, MAX_QUANTITY },
                { IngredientType.DecafCoffee, MAX_QUANTITY },
                { IngredientType.Sugar, MAX_QUANTITY },
                { IngredientType.Cream, MAX_QUANTITY },
                { IngredientType.SteamedMilk, MAX_QUANTITY },
                { IngredientType.FoamedMilk, MAX_QUANTITY },
                { IngredientType.Espresso, MAX_QUANTITY },
                { IngredientType.Cocoa, MAX_QUANTITY },
                { IngredientType.WhippedCream, MAX_QUANTITY },
            };
        }

        /// <summary>
        /// Displays the list of ingredients in inventory and their available quantities
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Inventory:");
            foreach (KeyValuePair<string, int> entry in IngredientsQty)
            {
                Ingredient ingredient = GetIngredient(entry.Key);
                if(!string.IsNullOrEmpty(ingredient.Name))
                    Console.WriteLine(string.Format("{0},{1}", ingredient.Name, entry.Value));
            }
        }

        /// <summary>
        /// Gets the ingredient from inventory
        /// </summary>
        /// <param name="name">Name of ingredient</param>
        /// <returns>Ingredient object</returns>
        public Ingredient GetIngredient(string name)
        {
            Ingredient ingredient = new Ingredient();
            if(Ingredients.ContainsKey(name))
            {
                ingredient = Ingredients[name];
            }
            return ingredient;
        }

        /// <summary>
        /// Get available quantity of ingredient
        /// </summary>
        /// <param name="name">Name of ingredient</param>
        /// <returns>Ingredient avialable quantity</returns>
        public int GetIngredientAvailableQty(string name)
        {
            int quntity = 0;
            if (IngredientsQty.ContainsKey(name))
            {
                quntity = IngredientsQty[name];
            }
            return quntity;
        }

        /// <summary>
        /// Checks whether ingredient available in inventory
        /// </summary>
        /// <param name="name">Ingredient Name</param>
        /// <param name="requiredQty">Required quantity of ingredient</param>
        /// <returns>True/False</returns>
        public bool IsAvailable(string name, int requiredQty)
        {
            try
            {
                IngredientsQty.TryGetValue(name, out var availableQty);
                if (availableQty >= requiredQty)
                    return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occurred While Checking Ingredient Availability: " + ex.Message);
                return false;
            }
            return false;
        }

        /// <summary>
        /// Dispense the ingredient from inventory
        /// </summary>
        /// <param name="name">Ingredient Name</param>
        /// <param name="requiredQty">Required quantity of ingredient</param>
        public void DispenseIngredient(string name, int requiredQty)
        {
            try
            {
                if (requiredQty < 0)
                {
                    throw new Exception("Required quantity cannot be negative");
                }
                IngredientsQty.TryGetValue(name, out var availableQty);
                if (availableQty > 0)
                    IngredientsQty[name] = availableQty - requiredQty;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occurred While Dispensing Ingredient: " + ex.Message);
                return;
            }
        }

        /// <summary>
        /// Refills the all ingredients in inventory to it's maximum
        /// </summary>
        public void Restock()
        {
            try
            {
                foreach (KeyValuePair<string, Ingredient> entry in Ingredients)
                {
                    IngredientsQty[entry.Key] = MAX_QUANTITY;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error Occurred While Restocking Inventory: " + ex.Message);
                return;
            }
        }
    }
}
