using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IFollowerEndpoint : IEndpoint
    {
        Task<Follower> GetFollowerAsync(IAuthenticationScope authenticationScope, FollowerIdentifier followerId);
    }
}