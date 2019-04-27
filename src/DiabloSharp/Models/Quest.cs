using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Quest : ModelBase<long>
    {
        public string Name { get; internal set; }

        public string Slug { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            builder.AppendProperty(nameof(Slug), Slug);
            return builder;
        }
    }
}