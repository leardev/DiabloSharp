using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Artisan : ModelBase<ArtisanId>
    {
        public string Name { get; internal set; }

        public string Portrait { get; internal set; }

        public IEnumerable<ArtisanRecipe> Recipes { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}