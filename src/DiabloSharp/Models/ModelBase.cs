using System.Text;

namespace DiabloSharp.Models
{
    public abstract class ModelBase
    {
        public override string ToString()
        {
            var builder = ToBuilder();

            if (builder.Length == 0)
                return base.ToString();

            return builder.ToString(0, builder.Length - 2);
        }

        protected virtual StringBuilder ToBuilder()
        {
            return new StringBuilder();
        }
    }

    public abstract class ModelBase<TIdentifier> : ModelBase
    {
        public TIdentifier Id { get; internal set; }
    }
}