using AutoFixture;
using AutoFixture.AutoMoq;
using CsvHelper;
using i502Club.Ccrs.Interfaces;
using i502Club.Ccrs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace i502Club.Ccrs.Tests
{
    [TestClass]
    public class AreaTests : TestBase
    {
        [TestMethod]
        public void CreateAndRead()
        {
            var fileNamePrefix = "area_";

            if (_path == null)
            {
                Assert.Fail("Invalid _path");
                return;
            }

            TestHelpers.RemoveCsvFiles(_path);

            //create some items
            var items = new List<Area>();
            for (int i = 0; i < 4; i++)
            {
                Area area = GetArea(_user, i);

                items.Add(area);
            }

            //set up csv helper config
            var config = TestHelpers.GetConfig();

            //create the CCRS csv file
            using (var writer = new StreamWriter(_path + @"/" + fileNamePrefix + _licenseNumber + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".csv"))
            using (var csv = new CsvWriter(writer, config))
            {
                TestHelpers.CreateHeaderRows(_user, typeof(Area).GetProperties().Length, items.Count, csv);
                TestHelpers.InitConverters(csv);

                csv.WriteRecords(items);
            }

            //get area ccrs files
            var areaFiles = Directory.EnumerateFiles(_path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv") && s.Contains(fileNamePrefix));

            var testAreas = new List<Area>();

            if (areaFiles.Any())
            {
                foreach (var f in areaFiles)
                {
                    ProcessFile(config, testAreas, f);
                }
            }

            Assert.AreEqual(items.Count, testAreas.Count);
        }

        private static void ProcessFile(CsvHelper.Configuration.CsvConfiguration config, List<Area> testAreas, string f)
        {
            using (var reader = new StreamReader(f))
            using (var csv = new CsvReader(reader, config))
            {
                TestHelpers.SkipSummaryLines(csv);

                testAreas.AddRange(csv.GetRecords<Area>());
            }
        }

        private Area GetArea(User user, int i)
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var item = fixture.Create<Area>();
            return item;
        }
    }


}