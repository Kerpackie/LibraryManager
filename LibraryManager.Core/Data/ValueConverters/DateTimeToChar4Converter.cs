using System.Globalization;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LibraryManager.Core.Data.ValueConverters;

public class DateTimeToChar4Converter : ValueConverter<DateTime, string>
{
    public DateTimeToChar4Converter() : base(
        dateTime => dateTime.ToString("yyyy", CultureInfo.InvariantCulture),
        stringValue => DateTime.ParseExact(stringValue, "yyyy", CultureInfo.InvariantCulture)
    )
    { }
}