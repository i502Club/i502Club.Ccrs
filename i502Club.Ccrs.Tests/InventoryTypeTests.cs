using i502Club.Ccrs.Enums;
using i502Club.Ccrs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace i502Club.Ccrs.Tests
{
    [TestClass]
    public class InventoryTypeTests : TestBase
    {
        [TestMethod]
        public void InfusedCookingMediumUsesGram()
        {
            var p = new Product
            {
                InventoryType = InventoryType.InfusedCookingMedium
            };

            Assert.IsTrue(p.InventoryType.Uom == Uom.Gram);
        }

        [TestMethod]
        public void CO2ConcentrateIsEndProduct()
        {
            var p = new Product
            {
                InventoryType = InventoryType.CO2Concentrate
            };

            Assert.IsTrue(p.InventoryType.Category == InventoryCategory.EndProduct);
        }

        [TestMethod]
        public void HasDisplayName()
        {
            var item = new Product
            {
                InventoryType = InventoryType.CO2Concentrate
            };

            Assert.IsFalse(string.IsNullOrWhiteSpace(item.InventoryType.DisplayName));
        }

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

        [TestMethod]
        public void InventoryTypeFromValue()
        {
            var item = new Product
            {
                InventoryType = InventoryType.CO2Concentrate
            };

            var item2 = InventoryType.FromValue<InventoryType>(15);

            Assert.IsTrue(item.InventoryType.Equals(item2));
        }
    }
}