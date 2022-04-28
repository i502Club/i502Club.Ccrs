using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Linq;

namespace i502Club.Ccrs.Converters
{
    public class CustomBooleanConverter : BooleanConverter
    {

        public CustomBooleanConverter()
            : base()
        {
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

            return value.ToString().ToUpper();
        }
    }
}
