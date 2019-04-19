using DiabloSharp.Clients;
using DiabloSharp.Extensions;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public abstract class EndpointBase
    {
        internal BattleNetClient CreateClient(AuthenticationScope authenticationScope)
        {
            return new BattleNetClient(authenticationScope.AccessToken, authenticationScope.Region.ToDescription(),
                authenticationScope.Localization.ToDescription());
        }
    }
}