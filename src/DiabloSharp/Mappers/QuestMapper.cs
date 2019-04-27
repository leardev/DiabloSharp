using DiabloSharp.DataTransferObjects;
using DiabloSharp.Models;

namespace DiabloSharp.Mappers
{
    internal class QuestMapper : Mapper<ActQuestDto, Quest>
    {
        protected override void Map(ActQuestDto input, Quest output)
        {
            output.Id = input.Id;
            output.Slug = input.Slug;
            output.Name = input.Name;
        }
    }
}