using System.Text;

namespace DiabloSharp.Models
{
    public abstract class ModelBase
    {
        protected virtual StringBuilder ToBuilder()
        {
            return new StringBuilder();
        }

        public override string ToString()
        {
            var builder = ToBuilder();

            if (builder.Length == 0)
                return base.ToString();

            return builder.ToString(0, builder.Length - 2);
        }
    }

    public abstract class ModelBase<TIdentifier> : ModelBase
    {
        public TIdentifier Id { get; internal set; }
    }
}