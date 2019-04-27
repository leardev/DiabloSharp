using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class CharacterClass : ModelBase<CharacterClassIdentifier>
    {
        public string Name { get; internal set; }

        public string IconUrl { get; internal set; }

        public IEnumerable<CharacterName> Names { get; internal set; }

        public IEnumerable<SkillCharacterActive> ActiveSkills { get; internal set; }

        public IEnumerable<SkillCharacterPassive> PassiveSkills { get; internal set; }

        public IEnumerable<SkillCharacter> Skills { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}