namespace DiabloSharp.Models
{
    public abstract class ModelBase<TIdentifier>
    {
        public TIdentifier Id { get; }

        protected ModelBase(TIdentifier id)
        {
            Id = id;
        }
    }
}