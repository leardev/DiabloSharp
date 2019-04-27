using System;

namespace DiabloSharp.Exceptions
{
    public class DiabloApiEnumConversionException : DiabloApiException
    {
        public DiabloApiEnumConversionException(string parameter, object value) : base($"Parameter name: {parameter}{Environment.NewLine}Actual value was {value}.")
        {
        }
    }
}