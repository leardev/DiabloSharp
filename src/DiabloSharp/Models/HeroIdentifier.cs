using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class HeroIdentifier : ValueObject
    {
        public HeroIdentifier(string battleTag, long id)
        {
            BattleTag = new BattleTagIdentifier(battleTag);
            Id = id;
        }

        public BattleTagIdentifier BattleTag { get; }

        public long Id { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return BattleTag;
            yield return Id;
        }

        public override string ToString()
        {
            return $"{nameof(BattleTag)} = {BattleTag}, {nameof(Id)} = {Id}";
        }
    }
}