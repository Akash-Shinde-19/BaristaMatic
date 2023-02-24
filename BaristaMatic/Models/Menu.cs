using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaristaMatic.Models
{
    /// <summary>
    /// Menu class
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Dictionary to stores recipe
        /// </summary>
        private readonly SortedDictionary<string, Recipe> recipes;

        public Menu(Inventory inventory)
        {
            recipes = new SortedDictionary<string, Recipe>
            {
                { DrinkType.Coffee, new CoffeeRecipe(inventory) },
                { DrinkType.DecafCoffee, new DecafCoffeeRecipe(inventory) },
                { DrinkType.CaffeLatte, new CaffeLatteRecipe(inventory) },
                { DrinkType.CaffeAmericano, new CaffeAmericanoRecipe(inventory) },
                { DrinkType.CaffeMocha, new CaffeMochaRecipe(inventory) },
                { DrinkType.Cappuccino, new CappuccinoRecipe(inventory) },
            };
        }

        /// <summary>
        /// Displays the menu
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Menu:");
            int count = 1;
            foreach (KeyValuePair<string, Recipe> entry in recipes)
            {
                Recipe recipe = entry.Value;
                Console.WriteLine(string.Format("{0},{1},{2:$0.00},{3}", count++, recipe.Name, recipe.GetCost(), recipe.IsAvailable()));
            }
        }

        /// <summary>
        /// Makes drink
        /// </summary>
        /// <param name="name">Name of drink</param>
        public void MakeDrink(string name)
        {
            if(recipes.ContainsKey(name))
            {
                try
                {
                    recipes[name].MakeDrink();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Occurred While Making Drink: " + ex.Message);
                    return;
                }
            }
        }

        /// <summary>
        /// Makes drink
        /// </summary>
        /// <param name="index">Index of drink in dictionary</param>
        public void MakeDrink(int index)
        {
            if (index >= 0  && index < recipes.Count)
            {
                try
                {
                    recipes.ElementAt(index).Value.MakeDrink();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error Occurred While Making Drink: " + ex.Message);
                    return;
                }
            }
        }
    }
}
