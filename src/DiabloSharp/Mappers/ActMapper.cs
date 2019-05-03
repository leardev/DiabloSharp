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

            output.Id = (ActId)input.Id;
            output.Slug = input.Slug;
            output.Name = input.Name;
            output.Quests = quests;
        }

        private IEnumerable<ActQuest> MapQuests(IEnumerable<ActQuestDto> inputs)
        {
            var outputs = new List<ActQuest>();
            foreach (var input in inputs)
            {
                var output = MapQuest(input);
                outputs.Add(output);
            }

            return outputs;
        }

        private ActQuest MapQuest(ActQuestDto input)
        {
            return new ActQuest
            {
                Id = input.Id,
                Slug = input.Slug,
                Name = input.Name
            };
        }
    }
}