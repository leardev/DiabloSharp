using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class FollowerConverter
    {
        public Follower FollowerToModel(FollowerDto followerDto)
        {
            var skills = followerDto.Skills.Select(SkillToDto);

            return new Follower
            {
                Id = followerDto.Slug,
                Name = followerDto.Name,
                RealName = followerDto.RealName,
                Portrait = followerDto.Portrait,
                Skills = skills
            };
        }

        private SkillFollower SkillToDto(FollowerSkillDto followerSkillDto)
        {
            var tooltip = new Tooltip
            {
                Url = followerSkillDto.TooltipUrl,
                Description = followerSkillDto.Description,
                DescriptionHtml = followerSkillDto.DescriptionHtml,
                IconUrl = followerSkillDto.Icon
            };

            return new SkillFollower
            {
                Id = followerSkillDto.Slug,
                Name = followerSkillDto.Name,
                Level = followerSkillDto.Level,
                Tooltip = tooltip
            };
        }
    }
}