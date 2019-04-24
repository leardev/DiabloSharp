using System.Collections.Generic;
using DiabloSharp.Infrastructure;

namespace DiabloSharp.Models
{
    public class HeroIdentifier : ValueObject
    {
        #region lookup-table

        public static HeroIdentifier Empty { get; }

        static HeroIdentifier()
        {
            Empty = new HeroIdentifier(-1, string.Empty);
        }

        #endregion

        public HeroIdentifier(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public long Id { get; }

        public string Name { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
            yield return Name;
        }

        public override string ToString()
        {
            return $"{nameof(Id)} = {Id}, {nameof(Name)} = {Name}";
        }
    }
}