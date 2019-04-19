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
            return new Act(actId, actDto.Slug, actDto.Name, quests);
        }

        private Quest QuestToModel(ActQuestDto questDto)
        {
            return new Quest(questDto.Id, questDto.Name, questDto.Slug);
        }
    }
}