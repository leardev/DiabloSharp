namespace DiabloSharp.Models
{
    public class Quest
    {
        public Quest(long id, string name, string slug)
        {
            Id = id;
            Name = name;
            Slug = slug;
        }

        public long Id { get; }

        public string Name { get; }

        public string Slug { get; }
    }
}