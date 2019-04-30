using System.Collections.Generic;

namespace DiabloSharp.Mappers
{
    internal abstract class Mapper<TIn, TOut>
        where TOut: new()
    {
        protected abstract void Map(TIn input, TOut output);

        public TOut Map(TIn input)
        {
            var output = new TOut();
            Map(input, output);
            return output;
        }

        public IEnumerable<TOut> Map(IEnumerable<TIn> inputs)
        {
            var outputs = new List<TOut>();
            foreach (var input in inputs)
            {
                var output = Map(input);
                outputs.Add(output);
            }
            return outputs;
        }
    }
}