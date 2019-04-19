namespace DiabloSharp.Models
{
    public abstract class ModelBase<TIdentifier>
    {
        public TIdentifier Id { get; internal set; }
    }
}