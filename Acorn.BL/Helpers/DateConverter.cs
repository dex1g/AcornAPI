using Newtonsoft.Json.Converters;

namespace Acorn.BL.Helpers
{
    public class DateConverter : IsoDateTimeConverter
    {
        public DateConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
