using DiabloSharp.Endpoints;

namespace DiabloSharp
{
    public interface IDiabloApi
    {
        IAuthenticationScope CreateAuthenticationScope(); 
    }
}