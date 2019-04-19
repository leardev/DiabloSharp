using System.Collections.Generic;
using System.Linq;
using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Converters
{
    internal class ActConverter
    {
        public IEnumerable<Act> ActIndexToModel(ActIndexDto actIndexDto)
        {
            return actIndexDto.Acts
                .Select(ActToModel);
        }

        public Act ActToModel(ActDto actDto)
        {
            var quests = actDto.Quests.Select(QuestToModel);
            var actId = (ActIdentifier) actDto.Id;

            return new Act
            {
                Id = actId,
                Slug = actDto.Slug,
                Name = actDto.Name,
                Quests = quests
            };
        }

        private Quest QuestToModel(ActQuestDto questDto)
        {
            return new Quest
            {
                Id = questDto.Id,
                Slug = questDto.Slug,
                Name = questDto.Name,
            };
        }
    }
}