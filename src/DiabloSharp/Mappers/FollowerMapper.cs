using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class FollowerMapper : Mapper<FollowerDto, Follower>
    {
        protected override void Map(FollowerDto input, Follower output)
        {
            var skills = MapSkills(input.Skills);

            output.Id = input.Slug;
            output.Name = input.Name;
            output.RealName = input.RealName;
            output.Portrait = input.Portrait;
            output.Skills = skills;
        }

        private IEnumerable<SkillFollower> MapSkills(IEnumerable<FollowerSkillDto> inputs)
        {
            var outputs = new List<SkillFollower>();
            foreach (var input in inputs)
            {
                var output = MapSkill(input);
                outputs.Add(output);
            }
            return outputs;
        }

        private SkillFollower MapSkill(FollowerSkillDto input)
        {
            return new SkillFollower
            {
                Id = input.Slug,
                Name = input.Name,
                Level = input.Level,
                IconUrl = input.Icon,
                TooltipUrl = input.TooltipUrl
            };
        }
    }
}