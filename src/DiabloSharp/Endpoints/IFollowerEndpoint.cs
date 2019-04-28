using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IFollowerEndpoint : IEndpoint
    {
        Task<Follower> GetFollowerAsync(IAuthenticationScope authenticationScope, FollowerId followerId);

        Task<IEnumerable<Follower>> GetFollowersAsync(IAuthenticationScope authenticationScope);
    }
}