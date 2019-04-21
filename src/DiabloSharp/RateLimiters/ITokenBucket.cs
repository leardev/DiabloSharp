using System.Threading.Tasks;

namespace DiabloSharp.RateLimiters
{
    public interface ITokenBucket
    {
        long Remaining { get; }

        Task ConsumeAsync();
    }
}