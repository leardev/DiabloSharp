using System.Runtime.Serialization;

namespace DiabloSharp.DataTransferObjects
{
    [DataContract]
    public class ItemHtmlDescriptionDto
    {
        [DataMember(Name = "textHtml")]
        public string TextHtml { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}