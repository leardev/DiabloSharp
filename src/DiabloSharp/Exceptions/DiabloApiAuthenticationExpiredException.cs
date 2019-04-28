namespace DiabloSharp.Exceptions
{
    internal class DiabloApiAuthenticationExpiredException : DiabloApiException
    {
        public DiabloApiAuthenticationExpiredException() : base("Authentication scope is expired.")
        {
        }
    }
}