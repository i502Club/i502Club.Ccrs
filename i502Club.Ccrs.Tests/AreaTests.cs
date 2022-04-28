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
    public class AreaTests : TestBase
    {
        [TestMethod]
        public void CreateAndRead()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileNamePrefix = "area_";

            User user = GetUser();

            if (path == null)
            {
                Assert.Fail("Invalid path");
                return;
            }

            RemoveCsvFiles(path);

            //create some areas
            var areas = new List<Area>();
            for (int i = 0; i < 4; i++)
            {

                var area = new Area
                {
                    Name = "Area" + i,
                    LicenseNumber = _licenseNumber,
                    ExternalIdentifier = "ExternalIdentifier" + i,
                    IsQuarantine = false,
                    Operation = "INSERT",
                    CreatedDate = DateTime.Parse("04/20/2022"),
                    CreatedBy = user.FirstName + " " + user.LastName
                };

                areas.Add(area);
            }

            //set up csv helper config
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null
            };

            //create the CCRS csv file
            using (var writer = new StreamWriter(path + @"/" + fileNamePrefix + _licenseNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                CreateHeaderRows(user, typeof(i502Club.Ccrs.Models.Area).GetProperties().Length, areas.Count, csv);

                InitConverters(csv);

                csv.WriteRecords(areas);
            }

            //get area ccrs files
            var areaFiles = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv") && s.Contains(fileNamePrefix));

            var testAreas = new List<Area>();

            if (areaFiles.Any())
            {
                foreach (var f in areaFiles)
                {
                    using (var reader = new StreamReader(f))
                    using (var csv = new CsvReader(reader, config))
                    {
                        SkipSummaryLines(csv);

                        testAreas.AddRange(csv.GetRecords<Area>());
                    }
                }
            }

            Assert.AreEqual(areas.Count, testAreas.Count);
        }
    }


}