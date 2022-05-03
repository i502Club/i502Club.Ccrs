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
    public class PlantTests : TestBase
    {
        [TestMethod]
        public void CreateAndRead()
        {
            if (_path == null)
            {
                Assert.Fail("Invalid _path");
                return;
            }

            var fileNamePrefix = "plant_";
            TestHelpers.RemoveCsvFiles(_path);

            //create some plants
            var items = new List<Plant>();
            for (int i = 0; i < 4; i++)
            {
                var fixture = new Fixture().Customize(new AutoMoqCustomization());
                var item = fixture.Create<Plant>();
                items.Add(item);
            }

            //set up csv helper config
            var config = TestHelpers.GetConfig();

            //create the CCRS csv file
            using (var writer = new StreamWriter(_path + @"/" + fileNamePrefix + _licenseNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                TestHelpers.CreateHeaderRows(_user, typeof(i502Club.Ccrs.Models.Plant).GetProperties().Length, items.Count, csv);
                TestHelpers.InitConverters(csv);

                csv.WriteRecords(items);
            }

            //get plant ccrs files
            var plantFiles = Directory.EnumerateFiles(_path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv") && s.Contains(fileNamePrefix));

            var testplants = new List<Plant>();

            if (plantFiles.Any())
            {
                foreach (var f in plantFiles)
                {
                    using (var reader = new StreamReader(f))
                    using (var csv = new CsvReader(reader, config))
                    {
                        TestHelpers.SkipSummaryLines(csv);

                        testplants.AddRange(csv.GetRecords<Plant>());
                    }
                }
            }

            Assert.AreEqual(items.Count, testplants.Count);
        }
    }
}