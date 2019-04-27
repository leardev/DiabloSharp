using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class ActMapper : Mapper<ActDto, Act>
    {
        protected override void Map(ActDto input, Act output)
        {
            var questMapper = new QuestMapper();
            var quests = questMapper.Map(input.Quests);

            output.Id = (ActIdentifier)input.Id;
            output.Slug = input.Slug;
            output.Name = input.Name;
            output.Quests = quests;
        }
    }
}