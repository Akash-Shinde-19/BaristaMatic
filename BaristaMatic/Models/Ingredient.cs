using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BaristaMatic.Models
{
    /// <summary>
    /// Ingredient class
    /// </summary>
    public class Ingredient
    {
        /// <summary>
        /// Name of ingredient
        /// </summary>
        private readonly string name = string.Empty;

        /// <summary>
        /// Cost of ingredient
        /// </summary>
        private readonly double cost = 0;

        public Ingredient() { }

        public Ingredient(string name, double cost)
        {
            this.name = name;
            this.cost = cost;
        }

        public string Name { get { return name; } }
        public double Cost { get { return cost; } }
    }

    /// <summary>
    /// Coffee class inherited from Ingredient class
    /// </summary>
    public class Coffee : Ingredient
    {
        public Coffee(): base(IngredientType.Coffee, 0.75) { }
    }

    /// <summary>
    /// DecafCoffee class inherited from Ingredient class
    /// </summary>
    public class DecafCoffee : Ingredient
    {
        public DecafCoffee() : base(IngredientType.DecafCoffee, 0.75) { }
    }

    /// <summary>
    /// Sugar class inherited from Ingredient class
    /// </summary>
    public class Sugar : Ingredient
    {
        public Sugar() : base(IngredientType.Sugar, 0.25) { }
    }

    /// <summary>
    /// Cream class inherited from Ingredient class
    /// </summary>
    public class Cream : Ingredient
    {
        public Cream() : base(IngredientType.Cream, 0.25) { }
    }

    /// <summary>
    /// SteamedMilk class inherited from Ingredient class
    /// </summary>
    public class SteamedMilk : Ingredient
    {
        public SteamedMilk() : base(IngredientType.SteamedMilk, 0.35) { }
    }

    /// <summary>
    /// FoamedMilk class inherited from Ingredient class
    /// </summary>
    public class FoamedMilk : Ingredient
    {
        public FoamedMilk() : base(IngredientType.FoamedMilk, 0.35) { }
    }

    /// <summary>
    /// Espresso class inherited from Ingredient class
    /// </summary>
    public class Espresso : Ingredient
    {
        public Espresso() : base(IngredientType.Espresso, 1.10) { }
    }

    /// <summary>
    /// Cocoa class inherited from Ingredient class
    /// </summary>
    public class Cocoa : Ingredient
    {
        public Cocoa() : base(IngredientType.Cocoa, 0.90) { }
    }

    /// <summary>
    /// WhippedCream class inherited from Ingredient class
    /// </summary>
    public class WhippedCream : Ingredient
    {
        public WhippedCream() : base(IngredientType.WhippedCream, 1.00) { }
    }
}
