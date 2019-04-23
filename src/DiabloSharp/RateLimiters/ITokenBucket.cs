using System.Threading.Tasks;

namespace DiabloSharp.RateLimiters
{
    public interface ITokenBucket
    {
        Task ConsumeAsync();
    }
}