using CsvHelper;
using i502Club.Ccrs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileNamePrefix = "inventory_";

            User user = GetUser();

            if (path == null)
            {
                Assert.Fail("Invalid path");
                return;
            }

            RemoveCsvFiles(path);

            //create some inventorys
            var inventorys = new List<Inventory>();
            for (int i = 0; i < 4; i++)
            {

                var inventory = new Inventory
                {
                    Product = "inventory name" + i,
                    LicenseNumber = _licenseNumber,
                    ExternalIdentifier = "ExternalIdentifier" + i,
                    Area = "Testing Area",
                    InitialQuantity = i + 30,
                    QuantityOnHand = i,
                    TotalCost = i * 25,
                    IsMedical = false,
                    Strain = "strain" +i,
                    Operation = "INSERT",
                    CreatedDate = DateTime.Parse("04/20/2022"),
                    CreatedBy = user.FirstName + " " + user.LastName
                };

                inventorys.Add(inventory);
            }

            //set up csv helper config
            var config = GetConfig();

            //create the CCRS csv file
            using (var writer = new StreamWriter(path + @"/" + fileNamePrefix + _licenseNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                CreateHeaderRows(user, typeof(i502Club.Ccrs.Models.Inventory).GetProperties().Length, inventorys.Count, csv);

                InitConverters(csv);

                csv.WriteRecords(inventorys);
            }

            //get inventory ccrs files
            var inventoryFiles = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv") && s.Contains(fileNamePrefix));

            var testinventorys = new List<Inventory>();

            if (inventoryFiles.Any())
            {
                foreach (var f in inventoryFiles)
                {
                    using (var reader = new StreamReader(f))
                    using (var csv = new CsvReader(reader, config))
                    {
                        SkipSummaryLines(csv);

                        testinventorys.AddRange(csv.GetRecords<Inventory>());
                    }
                }
            }

            Assert.AreEqual(inventorys.Count, testinventorys.Count);
        }
    }


}