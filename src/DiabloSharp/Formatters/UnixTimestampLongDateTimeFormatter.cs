using System;
using Utf8Json;

namespace DiabloSharp.Formatters
{
    internal sealed class UnixTimestampLongDateTimeFormatter : IJsonFormatter<DateTime>
    {
        internal static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public void Serialize(ref JsonWriter writer, DateTime value, IJsonFormatterResolver formatterResolver)
        {
            var ticks = (long)(value.ToUniversalTime() - UnixEpoch).TotalSeconds;
            writer.WriteQuotation();
            writer.WriteInt64(ticks);
            writer.WriteQuotation();
        }

        public DateTime Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
        {
            var ticks = reader.ReadUInt64();
            return UnixEpoch.AddSeconds(ticks);
        }
    }
}
