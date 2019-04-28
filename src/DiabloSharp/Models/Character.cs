using System.Collections.Generic;
using System.Text;
using DiabloSharp.Extensions;

namespace DiabloSharp.Models
{
    public class Character : ModelBase<CharacterId>
    {
        public string Name { get; internal set; }

        public string IconUrl { get; internal set; }

        public IEnumerable<CharacterName> Names { get; internal set; }

        public IEnumerable<CharacterSkillActive> ActiveSkills { get; internal set; }

        public IEnumerable<CharacterSkillPassive> PassiveSkills { get; internal set; }

        public IEnumerable<CharacterSkillCategory> Categories { get; internal set; }

        public IEnumerable<CharacterSkill> Skills { get; internal set; }

        protected override StringBuilder ToBuilder()
        {
            var builder = base.ToBuilder();
            builder.AppendProperty(nameof(Id), Id.ToString());
            builder.AppendProperty(nameof(Name), Name);
            return builder;
        }
    }
}