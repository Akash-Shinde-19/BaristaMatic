using BaristaMatic.Models;


namespace UnitTestBaristaMatic
{
    [TestClass]
    public class RecipeTests
    {
        readonly Inventory inventory;
        readonly Recipe recipe;

        public RecipeTests()
        {
            inventory = new();
            recipe = new("Custom", inventory);
        }

        [TestMethod]
        public void TestMakeDrink()
        {
            int expectedCoffeeQty = 6, expectedSugarQty = 5, expectedFoamedMilkQty = 4;

            // Setup Custom Recipe Ingredients
            recipe.AddIngredient(IngredientType.Coffee, 4);
            recipe.AddIngredient(IngredientType.Sugar, 5);
            recipe.AddIngredient(IngredientType.FoamedMilk, 6);

            // Act
            recipe.MakeDrink();
            int availableCoffeeQty, availableSugarQty, availableFoamedMilkQty;
            availableCoffeeQty = inventory.GetIngredientAvailableQty(IngredientType.Coffee);
            availableSugarQty = inventory.GetIngredientAvailableQty(IngredientType.Sugar);
            availableFoamedMilkQty = inventory.GetIngredientAvailableQty(IngredientType.FoamedMilk);

            //Assert
            Assert.AreEqual(expectedCoffeeQty, availableCoffeeQty);
            Assert.AreEqual(expectedSugarQty, availableSugarQty);
            Assert.AreEqual(expectedFoamedMilkQty, availableFoamedMilkQty);
        }
    }
}
