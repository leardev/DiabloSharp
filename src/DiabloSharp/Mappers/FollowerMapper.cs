using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class FollowerMapper : Mapper<FollowerDto, Follower>
    {
        protected override void Map(FollowerDto input, Follower output)
        {
            var followerId = EnumConversionHelper.FollowerIdentifierFromString(input.Slug);
            var skills = MapSkills(followerId, input.Skills);

            output.Id = followerId;
            output.Name = input.Name;
            output.RealName = input.RealName;
            output.Portrait = input.Portrait;
            output.Skills = skills;
        }

        private IEnumerable<FollowerSkill> MapSkills(FollowerIdentifier followerId, IEnumerable<FollowerSkillDto> inputs)
        {
            var outputs = new List<FollowerSkill>();
            foreach (var input in inputs)
            {
                var output = MapSkill(followerId, input);
                outputs.Add(output);
            }
            return outputs;
        }

        private FollowerSkill MapSkill(FollowerIdentifier followerId, FollowerSkillDto input)
        {
            return new FollowerSkill
            {
                Id = new FollowerSkillIdentifier(followerId, input.Slug),
                Name = input.Name,
                Level = input.Level,
                IconUrl = input.Icon,
                TooltipUrl = input.TooltipUrl
            };
        }
    }
}