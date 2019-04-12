using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class Tier
    {
        [DataMember(Name = "tier")]
        public long Index { get; set; }

        [DataMember(Name = "trainedRecipes")]
        public IEnumerable<Recipe> TrainedRecipes { get; set; }

        [DataMember(Name = "taughtRecipes")]
        public IEnumerable<Recipe> TaughtRecipes { get; set; }
    }
}