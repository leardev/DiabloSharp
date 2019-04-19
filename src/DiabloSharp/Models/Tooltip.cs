namespace DiabloSharp.Models
{
    public class Tooltip
    {
        public Tooltip()
        {
            Url = string.Empty;
            IconUrl = string.Empty;
            Description = string.Empty;
            DescriptionHtml = string.Empty;
            FlavorText = string.Empty;
            FlavorTextHtml = string.Empty;
        }

        public string Url { get; internal set; }

        public string IconUrl { get; internal set; }

        public string Description { get; internal set; }

        public string DescriptionHtml { get; internal set; }

        public string FlavorText { get; internal set; }

        public string FlavorTextHtml { get; internal set; }
    }
}