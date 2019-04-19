namespace DiabloSharp.Models
{
    public class Quest : ModelBase<long>
    {
        public string Name { get; internal set; }

        public string Slug { get; internal set; }
    }
}