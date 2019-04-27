using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    internal class OAuthToken : ModelBase
    {
        public string AccessToken { get; internal set; }

        public long SecondsUntilExpiration { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(AccessToken), AccessToken);
            builder.AppendProperty(nameof(SecondsUntilExpiration), SecondsUntilExpiration.ToString());
            return builder;
        }
    }
}