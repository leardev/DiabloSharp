using System.Collections.Generic;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class ActMapper : Mapper<ActDto, Act>
    {
        protected override void Map(ActDto input, Act output)
        {
            var quests = MapQuests(input.Quests);

            output.Id = (ActIdentifier)input.Id;
            output.Slug = input.Slug;
            output.Name = input.Name;
            output.Quests = quests;
        }

        private IEnumerable<Quest> MapQuests(IEnumerable<ActQuestDto> inputs)
        {
            var outputs = new List<Quest>();
            foreach (var input in inputs)
            {
                var output = MapQuest(input);
                outputs.Add(output);
            }
            return outputs;
        }

        private Quest MapQuest(ActQuestDto input)
        {
            return new Quest
            {
                Id = input.Id,
                Slug = input.Slug,
                Name = input.Name
            };
        }
    }
}