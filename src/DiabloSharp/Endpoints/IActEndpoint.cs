using System.Collections.Generic;
using System.Threading.Tasks;
using DiabloSharp.Models;

namespace DiabloSharp.Endpoints
{
    public interface IActEndpoint : IEndpoint
    {
        Task<IEnumerable<Act>> GetActsAsync(IAuthenticationScope authenticationScope);

        Task<Act> GetActAsync(IAuthenticationScope authenticationScope, ActIdentifier actId);
    }
}