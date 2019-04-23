using System;
using DiabloSharp.RateLimiters;
using DiabloSharp.Tests.Mocks;
using NUnit.Framework;

namespace DiabloSharp.Tests.RateLimiters
{
    [TestFixture]
    public class RefillStrategyTests
    {
        private const long RefillCount = 5;

        private TimeSpan _refillPeriod;

        private DateTimeMock _dateTime;

        private RefillStrategy _refillStrategy;

        [SetUp]
        public void Setup()
        {
            _dateTime = new DateTimeMock(DateTime.MinValue);
            _refillPeriod = TimeSpan.FromSeconds(10);
            _refillStrategy = new RefillStrategy(_dateTime, RefillCount, _refillPeriod);
        }

        [Test]
        public void RefillInitialTest()
        {
            Assert.AreEqual(RefillCount, _refillStrategy.Refill());
        }

        [Test]
        public void RefillWithoutResetTest()
        {
            _refillStrategy.Refill();

            for (var i = 0; i < _refillPeriod.TotalSeconds - 1; i++)
            {
                _dateTime.AdvanceSeconds(1);
                Assert.AreEqual(0, _refillStrategy.Refill());
            }
        }

        [Test]
        public void RefillAfterPeriodTest()
        {
            for (var i = 0; i < 10; i++)
            {
                Assert.AreEqual(RefillCount, _refillStrategy.Refill());
                _dateTime.Advance(_refillPeriod);
            }
        }

        [Test]
        public void RefillAsyncToPeriodTest()
        {
            _dateTime.AdvanceSeconds(_refillPeriod.TotalSeconds / 2);
            Assert.AreEqual(RefillCount, _refillStrategy.Refill());

            _dateTime.AdvanceSeconds(_refillPeriod.TotalSeconds / 2);
            Assert.AreEqual(RefillCount, _refillStrategy.Refill());
        }

        [Test]
        public void RefillAndSkipPeriodsTest()
        {
            /* we cannot build up tokens over time */
            _dateTime.AdvanceSeconds(_refillPeriod.TotalSeconds * 3);
            Assert.AreEqual(RefillCount, _refillStrategy.Refill());

            _dateTime.Advance(_refillPeriod);
            Assert.AreEqual(RefillCount, _refillStrategy.Refill());
        }
    }
}