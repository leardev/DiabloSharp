using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    internal class DetailedItemTransmogDto : ItemIdentifierDto
    {
        [DataMember(Name = "displayColor")]
        public string DisplayColor { get; set; }
    }
}