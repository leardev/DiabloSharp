namespace DiabloSharp.Parsers
{
    internal class TokenMatch
    {
        public TokenType TokenType { get; set; }
        public string Value { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public int Precedence { get; set; }

        public override string ToString()
        {
            return $"{nameof(TokenType)} = {{{TokenType}}}, {nameof(Value)} = {{{Value}}}, ";
        }
    }
}