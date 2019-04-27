using System;
using System.Threading.Tasks;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.RateLimiters
{
    internal class TokenBucket : ITokenBucket
    {
        private readonly long _capacity;

        private readonly RefillStrategy _refillStrategy;

        private readonly object _syncRoot;

        public TokenBucket(long capacity, long refillCount, TimeSpan refillPeriod, IDateTime dateTime)
        {
            _capacity = capacity;
            _refillStrategy = new RefillStrategy(dateTime, refillCount, refillPeriod);
            _syncRoot = new object();
        }

        public long Remaining { get; private set; }

        public async Task ConsumeAsync()
        {
            while (true)
            {
                if (TryConsume(1))
                    break;
                await Task.Delay(1);
            }
        }

        public bool TryConsume(long tokenCount)
        {
            lock (_syncRoot)
            {
                var tokenCountToRefill = _refillStrategy.Refill();

                /* ensure that the refill count is positiv */
                tokenCountToRefill = Math.Max(0, tokenCountToRefill);

                /* ensure that the refill count does not exceed the capacity limit */
                tokenCountToRefill = Math.Min(_capacity, tokenCountToRefill);

                /* ensure that the refilled remaining token count does not exceed the capacity limit */
                Remaining = Math.Min(Remaining + tokenCountToRefill, _capacity);


                if (tokenCount > Remaining)
                    return false;

                Remaining -= tokenCount;
                return true;
            }
        }
    }
}