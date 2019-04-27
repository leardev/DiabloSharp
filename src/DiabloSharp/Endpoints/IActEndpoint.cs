using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IActEndpoint : IEndpoint
    {
        Task<IEnumerable<Act>> GetActsAsync(AuthenticationScope authenticationScope);

        Task<Act> GetActAsync(AuthenticationScope authenticationScope, ActIdentifier actId);
    }
}