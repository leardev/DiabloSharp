using System;
using System.Globalization;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    internal class AuthenticationScope : ModelBase,
                                         IAuthenticationScope
    {
        public DateTime ExpirationDate { get; internal set; }

        public string AccessToken { get; internal set; }

        public Localization Localization { get; internal set; }

        public Region Region { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder =  base.ToBuilder();
            builder.AppendProperty(nameof(AccessToken), AccessToken);
            builder.AppendProperty(nameof(Region), Region.ToString());
            builder.AppendProperty(nameof(Localization), Localization.ToString());
            builder.AppendProperty(nameof(ExpirationDate), ExpirationDate.ToString(CultureInfo.CurrentCulture));
            return builder;
        }
    }
}