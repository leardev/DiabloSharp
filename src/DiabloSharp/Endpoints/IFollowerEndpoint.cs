using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IFollowerEndpoint : IEndpoint
    {
        Task<Follower> GetFollowerAsync(AuthenticationScope authenticationScope, FollowerIdentifier followerId);
    }
}