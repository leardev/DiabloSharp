using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class ArtisanTier
    {
        [DataMember(Name = "tier")]
        public long Index { get; set; }

        [DataMember(Name = "trainedRecipes")]
        public IEnumerable<ArtisanRecipe> TrainedRecipes { get; set; }

        [DataMember(Name = "taughtRecipes")]
        public IEnumerable<ArtisanRecipe> TaughtRecipes { get; set; }
    }
}