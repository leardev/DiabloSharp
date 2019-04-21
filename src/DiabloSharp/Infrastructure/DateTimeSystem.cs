using System;

namespace DiabloSharp.Infrastructure
{
    internal class DateTimeSystem : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}