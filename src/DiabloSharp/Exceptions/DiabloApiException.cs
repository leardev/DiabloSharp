using System;

namespace DiabloSharp.Exceptions
{
    public class DiabloApiException : Exception
    {
        public DiabloApiException(string message) : base(message)
        {
        }
    }
}