using System.Threading.Tasks;

namespace DiabloSharp.RateLimiters
{
    internal interface ITokenBucket
    {
        Task ConsumeAsync();
    }
}