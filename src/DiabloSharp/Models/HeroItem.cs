using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public abstract class HeroItem : ModelBase<ItemId>
    {
        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            return builder;
        }
    }
}