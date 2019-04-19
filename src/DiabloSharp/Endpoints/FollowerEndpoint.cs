using System.Threading.Tasks;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public class FollowerEndpoint : EndpointBase
    {
        public async Task<FollowerDto> GetFollowerAsync(AuthenticationScope authenticationScope, string followerSlug)
        {
            using (var client = CreateClient(authenticationScope))
                return await client.GetFollowerAsync(followerSlug);
        }
    }
}