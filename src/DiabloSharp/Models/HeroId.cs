using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class HeroId : ValueObject
    {
        public HeroId(string battleTag, long id)
        {
            BattleTag = new BattleTagId(battleTag);
            Id = id;
        }

        public BattleTagId BattleTag { get; }

        public long Id { get; }

        public override string ToString()
        {
            return $"{nameof(BattleTag)} = {BattleTag}, {nameof(Id)} = {Id}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return BattleTag;
            yield return Id;
        }
    }
}