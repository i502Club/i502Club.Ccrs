using CsvHelper;
using i502Club.Ccrs.Models;
using i502Club.Ccrs.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace i502Club.Ccrs.Tests
{
    [TestClass]
    public class PlantDestructionTests : TestBase
    {
        [TestMethod]
        public void CreateAndRead()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileNamePrefix = "plantdestruction_";

            User user = GetUser();

            if (path == null)
            {
                Assert.Fail("Invalid path");
                return;
            }

            RemoveCsvFiles(path);

            //create some items
            var items = new List<PlantDestruction>();
            for (int i = 0; i < 4; i++)
            {

                var item = new PlantDestruction
                {
                    PlantExternalIdentifier = "PlantExternalIdentifier" + i,
                    DestructionReason = DestructionReason.Contamination,
                    DestructionMethod = DestructionMethod.Compost,
                    LicenseNumber = _licenseNumber,
                    Operation = "INSERT",
                    CreatedDate = DateTime.Parse("04/20/2022"),
                    CreatedBy = user.FirstName + " " + user.LastName
                };

                items.Add(item);
            }

            //set up csv helper config
            var config = GetConfig();

            //create the CCRS csv file
            using (var writer = new StreamWriter(path + @"/" + fileNamePrefix + _licenseNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                CreateHeaderRows(user, typeof(i502Club.Ccrs.Models.PlantDestruction).GetProperties().Length, items.Count, csv);

                InitConverters(csv);

                csv.WriteRecords(items);
            }

            //get ccrs files
            var files = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv") && s.Contains(fileNamePrefix));

            var testItems = new List<PlantDestruction>();

            if (files.Any())
            {
                foreach (var f in files)
                {
                    using (var reader = new StreamReader(f))
                    using (var csv = new CsvReader(reader, config))
                    {
                        SkipSummaryLines(csv);

                        testItems.AddRange(csv.GetRecords<PlantDestruction>());
                    }
                }
            }

            Assert.AreEqual(items.Count, testItems.Count);
        }
    }
}