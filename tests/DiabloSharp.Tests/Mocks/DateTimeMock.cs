using System;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Tests.Mocks
{
    internal class DateTimeMock : IDateTime
    {
        public DateTime Now { get; private set; }

        public DateTimeMock(DateTime now)
        {
            Now = now;
        }

        public void Advance(TimeSpan delta)
        {
            Now = Now.Add(delta);
        }

        public void AdvanceSeconds(double delta)
        {
            Now = Now.AddSeconds(delta);
        }
    }
}