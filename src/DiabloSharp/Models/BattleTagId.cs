using System.Collections.Generic;
using DiabloSharp.Exceptions;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class BattleTagId : ValueObject
    {
        public BattleTagId(string battleTag)
        {
            var parts = battleTag.Split('#');

            if (parts.Length != 2)
                throw new DiabloApiBattleTagException(battleTag);
            if (!long.TryParse(parts[1], out var index))
                throw new DiabloApiBattleTagException(battleTag);
            Index = index;
            Name = parts[0];
        }

        public string Name { get; }

        public long Index { get; }

        public override string ToString()
        {
            return $"{Name}#{Index}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Index;
            yield return Name;
        }
    }
}