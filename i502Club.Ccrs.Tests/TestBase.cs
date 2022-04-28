using CsvHelper;
using i502Club.Ccrs.Converters;
using i502Club.Ccrs.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace i502Club.Ccrs.Tests
{
    [TestClass]
    public class TestBase
    {
        public readonly string _licenseNumber = "123456";

        public static CsvHelper.Configuration.CsvConfiguration GetConfig()
        {
            return new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = false,
                MissingFieldFound = null
            };
        }

        public static void CreateHeaderRows(User userInfo, int numberColumns, int numberRecords, CsvWriter csv)
        {
            csv.WriteField("SubmittedBy");
            csv.WriteField(userInfo.FirstName + " " + userInfo.LastName);
            GenerateEmptyCols(numberColumns, csv);
            csv.NextRecord();

            csv.WriteField("SubmittedDate");
            csv.WriteField(DateTime.Now.ToShortDateString());
            GenerateEmptyCols(numberColumns, csv);
            csv.NextRecord();

            csv.WriteField("NumberRecords");
            csv.WriteField(numberRecords);
            GenerateEmptyCols(numberColumns, csv);
            csv.NextRecord();
        }
               

        private static void GenerateEmptyCols(int numberColumns, CsvWriter csv)
        {
            for (var i = 0; i < numberColumns - 2; i++)
            {
                csv.WriteField("");
            }
        }

        public static void InitConverters(CsvWriter csv)
        {
            csv.Context.TypeConverterCache.RemoveConverter<Boolean>();
            csv.Context.TypeConverterCache.AddConverter<Boolean>(new CustomBooleanConverter());

            csv.Context.TypeConverterCache.RemoveConverter<DateTime>();
            csv.Context.TypeConverterCache.RemoveConverter<DateTime?>();
            csv.Context.TypeConverterCache.AddConverter<DateTime?>(new CustomDateConverter("MM/dd/yyyy"));
            csv.Context.TypeConverterCache.AddConverter<DateTime>(new CustomDateConverter("MM/dd/yyyy"));
        }

        public static User GetUser()
        {
            return new User
            {
                FirstName = "Auxin",
                LastName = "Cotyledon"
            };
        }

        public static void SkipSummaryLines(CsvReader csv)
        {
            csv.Read();
            csv.Read();
            csv.Read();
        }

        public static void RemoveCsvFiles(string path)
        {
            //remove any csv files from this assembly's execution dir
            var filesToDelete = Directory.EnumerateFiles(path, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".csv"));
            foreach (var file in filesToDelete)
            {
                File.Delete(file);
            }
        }
    }
}