using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class ArtisanTierDto
    {
        [DataMember(Name = "tier")]
        public long Index { get; set; }

        [DataMember(Name = "trainedRecipes")]
        public IEnumerable<ArtisanRecipeDto> TrainedRecipes { get; set; }

        [DataMember(Name = "taughtRecipes")]
        public IEnumerable<ArtisanRecipeDto> TaughtRecipes { get; set; }
    }
}