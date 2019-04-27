using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class CharacterName : ModelBase<Gender>
    {
        public string Name { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}