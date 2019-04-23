using System;
using DiabloSharp.RateLimiters;
using DiabloSharp.Tests.Mocks;
using NUnit.Framework;

namespace DiabloSharp.Tests.RateLimiters
{
    [TestFixture]
    public class TokenBucketTests
    {
        private const long TokenCapacity = 5;

        private TimeSpan _refillPeriod;

        private DateTimeMock _dateTime;

        private TokenBucket _tokenBucket;

        [SetUp]
        public void Setup()
        {
            _dateTime = new DateTimeMock(DateTime.Today);
            _refillPeriod = TimeSpan.FromSeconds(10);
            _tokenBucket = new TokenBucket(TokenCapacity, TokenCapacity, _refillPeriod, _dateTime);
        }

        [Test]
        public void ConsumeTokenTest()
        {
            const long tokenConsumed = 3;
            const long tokenRemaining = 2;
            var couldConsume = _tokenBucket.TryConsume(tokenConsumed);

            Assert.IsTrue(couldConsume);
            Assert.AreEqual(tokenRemaining, _tokenBucket.Remaining);
        }

        [Test]
        public void ConsumeExactTokenCapacityTest()
        {
            var couldConsume = _tokenBucket.TryConsume(TokenCapacity);

            Assert.IsTrue(couldConsume);
            Assert.AreEqual(0, _tokenBucket.Remaining);
        }

        [Test]
        public void ConsumeExceedTokenCapacityTest()
        {
            var couldConsume = _tokenBucket.TryConsume(TokenCapacity + 1);

            Assert.IsFalse(couldConsume);
            Assert.AreEqual(TokenCapacity, _tokenBucket.Remaining);
        }

        [Test]
        public void ConsumeWithTimeAspect()
        {
            for (var second = 1; second <= 20; second++)
            {
                var consumed = _tokenBucket.TryConsume(1);

                switch (second)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 15:
                        Assert.IsTrue(consumed);
                        break;
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 16:
                    case 17:
                    case 18:
                    case 19:
                    case 20:
                        Assert.IsFalse(consumed);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                _dateTime.AdvanceSeconds(1);
            }
        }
    }
}