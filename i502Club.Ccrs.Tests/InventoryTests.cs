using AutoFixture;
using AutoFixture.AutoMoq;
using CsvHelper;
using i502Club.Ccrs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace i502Club.Ccrs.Tests
{
    [TestClass]
    public class InventoryTests : TestBase
    {
        [TestMethod]
        public void CreateAndRead()
        {
            var fileNamePrefix = "inventory_";

            if (_path == null)
            {
                Assert.Fail("Invalid _path");
                return;
            }

            TestHelpers.RemoveCsvFiles(_path);

            //create some items
            var items = new List<Inventory>();
            for (int i = 0; i < 4; i++)
            {

                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                var item = fixture.Create<Inventory>();

                items.Add(item);
            }

            //set up csv helper config
            var config = TestHelpers.GetConfig();

            //create the CCRS csv file
            using (var writer = new StreamWriter(_path + @"/" + fileNamePrefix + _licenseNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                TestHelpers.CreateHeaderRows(_user, typeof(Inventory).GetProperties().Length, items.Count, csv);
                TestHelpers.InitConverters(csv);

                csv.WriteRecords(items);
            }

            //get ccrs files
            var inventoryFiles = Directory.EnumerateFiles(_path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv") && s.Contains(fileNamePrefix));

            var testItems = new List<Inventory>();

            if (inventoryFiles.Any())
            {
                foreach (var f in inventoryFiles)
                {
                    using (var reader = new StreamReader(f))
                    using (var csv = new CsvReader(reader, config))
                    {
                        TestHelpers.SkipSummaryLines(csv);

                        testItems.AddRange(csv.GetRecords<Inventory>());
                    }
                }
            }

            Assert.AreEqual(items.Count, testItems.Count);
        }
    }


}