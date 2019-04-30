using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Mappers;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    internal class ActEndpoint : Endpoint,
                                 IActEndpoint
    {
        public ActEndpoint(ITokenBucket tokenBucket)
            : base(tokenBucket)
        {
        }

        public async Task<IEnumerable<Act>> GetActsAsync(IAuthenticationScope authenticationScope)
        {
            var mapper = new ActMapper();
            using (var client = CreateClient(authenticationScope))
            {
                var actIndex = await client.GetActIndexAsync();
                return mapper.Map(actIndex.Acts);
            }
        }

        public async Task<Act> GetActAsync(IAuthenticationScope authenticationScope, ActId actId)
        {
            var mapper = new ActMapper();
            var actIdIndex = (byte)actId;

            using (var client = CreateClient(authenticationScope))
            {
                var act = await client.GetActAsync(actIdIndex);
                return mapper.Map(act);
            }
        }
    }
}