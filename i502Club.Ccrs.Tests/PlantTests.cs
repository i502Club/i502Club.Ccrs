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
    public class PlantTests : TestBase
    {
        [TestMethod]
        public void CreateAndRead()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileNamePrefix = "plant_";

            User user = GetUser();

            if (path == null)
            {
                Assert.Fail("Invalid path");
                return;
            }

            RemoveCsvFiles(path);

            //create some plants
            var plants = new List<Plant>();
            for (int i = 0; i < 4; i++)
            {
                var plant = new Plant
                {
                    PlantIdentifier = "Plant" + i,
                    GrowthStage = Enums.GrowthStage.Immature,
                    PlantSource = Enums.PlantSource.Clone,
                    HarvestCycle = 12,
                    IsMotherPlant = false,
                    PlantState = Enums.PlantState.Growing,
                    Strain = "Strain" +i,

                    LicenseNumber = _licenseNumber,
                    ExternalIdentifier = "ExternalIdentifier" + i,
                    Operation = "INSERT",
                    CreatedDate = DateTime.Parse("04/20/2022"),
                    CreatedBy = user.FirstName + " " + user.LastName
                };

                plants.Add(plant);
            }

            //set up csv helper config
            var config = GetConfig();

            //create the CCRS csv file
            using (var writer = new StreamWriter(path + @"/" + fileNamePrefix + _licenseNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                CreateHeaderRows(user, typeof(i502Club.Ccrs.Models.Plant).GetProperties().Length, plants.Count, csv);

                InitConverters(csv);

                csv.WriteRecords(plants);
            }

            //get plant ccrs files
            var plantFiles = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv") && s.Contains(fileNamePrefix));

            var testplants = new List<Plant>();

            if (plantFiles.Any())
            {
                foreach (var f in plantFiles)
                {
                    using (var reader = new StreamReader(f))
                    using (var csv = new CsvReader(reader, config))
                    {
                        SkipSummaryLines(csv);

                        testplants.AddRange(csv.GetRecords<Plant>());
                    }
                }
            }

            Assert.AreEqual(plants.Count, testplants.Count);
        }
    }
}