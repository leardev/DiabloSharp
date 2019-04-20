using System;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace DiabloSharp.RateLimit
{
    internal class RateLimiter : IDisposable
    {
        private static readonly object LockObject = new object();

        private readonly int _maxCallCount;

        private readonly Timer _measureTimer;

        private int _performedCalls;

        public RateLimiter(int maxCallCount, TimeSpan timeSpan)
        {
            _maxCallCount = maxCallCount;
            _performedCalls = 0;
            _measureTimer = new Timer();
            _measureTimer.Elapsed += (sender, args) =>
            {
                lock (LockObject)
                {
                    _performedCalls = 0;
                }
            };
            _measureTimer.Interval = timeSpan.TotalMilliseconds;
            _measureTimer.Enabled = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task<T> Perform<T>(Func<Task<T>> performAction)
        {
            while (_performedCalls > _maxCallCount)
                Thread.Sleep(TimeSpan.FromMilliseconds(1));
            lock (LockObject)
            {
                _performedCalls++;
            }

            return performAction.Invoke();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
                _measureTimer?.Dispose();
        }

        ~RateLimiter()
        {
            Dispose(false);
        }
    }
}