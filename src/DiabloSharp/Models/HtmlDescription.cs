using System.Runtime.Serialization;

namespace DiabloSharp.Models
{
    [DataContract]
    public class HtmlDescription
    {
        [DataMember(Name = "textHtml")]
        public string TextHtml { get; set; }

        [DataMember(Name = "text")]
        public string Text { get; set; }
    }
}