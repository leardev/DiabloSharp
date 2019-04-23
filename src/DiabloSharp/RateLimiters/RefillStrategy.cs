using System;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.RateLimiters
{
    internal class RefillStrategy
    {
        private readonly IDateTime _dateTime;

        private readonly long _refillCount;

        private readonly TimeSpan _refillPeriod;

        private long _nextRefillTick;

        public RefillStrategy(IDateTime dateTime, long refillCount, TimeSpan refillPeriod)
        {
            _dateTime = dateTime;
            _refillCount = refillCount;
            _refillPeriod = refillPeriod;
            _nextRefillTick = dateTime.Now.Ticks;
        }

        public long Refill()
        {
            if (_dateTime.Now.Ticks < _nextRefillTick)
                return 0;

            _nextRefillTick += _refillPeriod.Ticks;
            return _refillCount;
        }
    }
}