namespace DiabloSharp.Models
{
    public abstract class ModelBase
    {
    }

    public abstract class ModelBase<TIdentifier> : ModelBase
    {
        public TIdentifier Id { get; internal set; }
    }
}