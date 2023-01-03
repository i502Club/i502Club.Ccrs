using i502Club.Ccrs.Enums;
using i502Club.Ccrs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace i502Club.Ccrs.Tests
{
    [TestClass]
    public class InventoryTypeTests : TestBase
    {

        [TestMethod]
        public void HasHashCode()
        {
            var item = new Product
            {
                InventoryType = InventoryType.CO2Concentrate
            };

            Assert.IsTrue(item.InventoryType.GetHashCode() > 0);
        }

        [TestMethod]
        public void ItemsAreNotEqual()
        {
            var item = new Product
            {
                InventoryType = InventoryType.CO2Concentrate
            };

            var item2 = new Product
            {
                InventoryType = InventoryType.EthanolConcentrate
            };

            Assert.IsFalse(item.InventoryType == item2.InventoryType);
        }

        [TestMethod]
        public void ObjectsNotEqual()
        {
            var item = new Product
            {
                InventoryType = InventoryType.CO2Concentrate
            };

            var item2 = InventoryType.CBD;

            Assert.IsFalse(item.Equals(item2));
        }

    }
}