using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Converters;
using DiabloSharp.Models;
using DiabloSharp.RateLimiters;

namespace DiabloSharp.Endpoints
{
    public class ActEndpoint : EndpointBase
    {
        private readonly ActConverter _actConverter;

        public ActEndpoint(ITokenBucket tokenBucket) : base(tokenBucket)
        {
            _actConverter = new ActConverter();
        }

        public async Task<IEnumerable<Act>> GetActsAsync(AuthenticationScope authenticationScope)
        {
            using (var client = CreateClient(authenticationScope))
            {
                var actIndex = await client.GetActIndexAsync();
                return _actConverter.ActIndexToModel(actIndex);
            }
        }

        public async Task<Act> GetActAsync(AuthenticationScope authenticationScope, ActIdentifier actId)
        {
            var actIdIndex = (byte) actId;

            using (var client = CreateClient(authenticationScope))
            {
                var act = await client.GetActAsync(actIdIndex);
                return _actConverter.ActToModel(act);
            }
        }
    }
}