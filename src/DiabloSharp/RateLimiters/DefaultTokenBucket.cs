using System;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.RateLimiters
{
    internal class DefaultTokenBucket : TokenBucket
    {
        public DefaultTokenBucket()
            : base(100, 100, TimeSpan.FromSeconds(1), new DateTimeSystem())
        {
        }
    }
}