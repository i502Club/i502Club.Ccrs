using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;
using System.Linq;

namespace i502Club.Ccrs.Converters
{
    public class CustomDateConverter : DateTimeConverter
    {
        private readonly string dateFormat;

        public CustomDateConverter(string dateFormat)
            : base()
        {
            this.dateFormat = dateFormat;
        }

        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            if (value == null)
            {
                if (memberMapData.TypeConverterOptions.NullValues.Count > 0)
                {
                    return memberMapData.TypeConverterOptions.NullValues.First();
                }

                return string.Empty;
            }

            if (value is IFormattable formattable)
            {
                var format = this.dateFormat;
                return formattable.ToString(format, memberMapData.TypeConverterOptions.CultureInfo);
            }

            return value.ToString();
        }
    }
}
