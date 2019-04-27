using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class ItemEquipmentSet : ModelBase
    {
        public string Name { get; internal set; }

        public IEnumerable<ItemIdentifier> ItemIds { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}