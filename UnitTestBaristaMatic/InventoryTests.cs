using BaristaMatic.Models;

namespace UnitTestBaristaMatic
{
    [TestClass]
    public class InventoryTests
    {
        readonly Inventory inventory;

        public InventoryTests()
        {
            inventory = new();
        }

        [TestMethod]
        public void TestGetIngredient()
        {
            Ingredient ingredient = inventory.GetIngredient(IngredientType.DecafCoffee);
            Assert.IsNotNull(ingredient);
            Assert.AreEqual("Decaf Coffee", ingredient.Name);
            Assert.AreNotEqual(0, ingredient.Cost);
        }

        [TestMethod]
        public void TestIsAvailable()
        {
            bool isAvailable;
            // Check for required qty < max
            isAvailable = inventory.IsAvailable(IngredientType.DecafCoffee, 3);
            Assert.IsTrue(isAvailable);

            // Check for required qty > max
            isAvailable = inventory.IsAvailable(IngredientType.DecafCoffee, 13);
            Assert.IsFalse(isAvailable);
        }

        [TestMethod]
        public void TestDispenseIngredient()
        {
            inventory.DispenseIngredient(IngredientType.DecafCoffee, 3);
            int qty = inventory.GetIngredientAvailableQty(IngredientType.DecafCoffee);
            Assert.AreEqual(7, qty);
        }

        [TestMethod]
        public void TestRestock()
        {
            int availableQty;
            inventory.DispenseIngredient(IngredientType.DecafCoffee, 3);
            availableQty = inventory.GetIngredientAvailableQty(IngredientType.DecafCoffee);
            Assert.AreEqual(7, availableQty);
            inventory.Restock();
            availableQty = inventory.GetIngredientAvailableQty(IngredientType.DecafCoffee);
            Assert.AreEqual(10, availableQty);
        }
    }
}