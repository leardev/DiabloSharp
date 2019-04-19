namespace DiabloSharp.Models
{
    public class Quest : ModelBase<long>
    {
        public Quest(long id, string name, string slug) : base(id)
        {
            Name = name;
            Slug = slug;
        }

        public string Name { get; }

        public string Slug { get; }
    }
}