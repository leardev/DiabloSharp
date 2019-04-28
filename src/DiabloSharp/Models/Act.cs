using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Act : ModelBase<ActIdentifier>
    {
        public string Slug { get; internal set; }

        public string Name { get; internal set; }

        public IEnumerable<ActQuest> Quests { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Slug), Slug);
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}