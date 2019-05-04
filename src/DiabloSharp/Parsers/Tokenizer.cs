using System.Collections.Generic;
using System.Linq;

namespace DiabloSharp.Parsers
{
    internal class Tokenizer
    {
        private readonly List<TokenDefinition> _tokenDefinitions;

        public Tokenizer()
        {
            _tokenDefinitions = new List<TokenDefinition>
            {
                new TokenDefinition(TokenType.Plus, "[+]", 1),
                new TokenDefinition(TokenType.Value, "[\\d.]+", 1),
                new TokenDefinition(TokenType.Percent, "%", 1),
                new TokenDefinition(TokenType.Text, "[^\\d\\W]+", 1),
                new TokenDefinition(TokenType.EndOfLine, "$", 1)
            };
        }

        public IEnumerable<TokenMatch> Tokenize(string text)
        {
            var tokenMatches = FindTokenMatches(text);

            var groupsByIndex = tokenMatches.GroupBy(x => x.StartIndex)
                .OrderBy(x => x.Key)
                .ToList();

            var matches = new List<TokenMatch>();
            var lastMatch = default(TokenMatch);
            foreach (var groupByIndex in groupsByIndex)
            {
                var bestMatch = groupByIndex.OrderBy(x => x.Precedence).First();
                if (lastMatch != null && bestMatch.StartIndex < lastMatch.EndIndex)
                    continue;

                matches.Add(bestMatch);
                lastMatch = bestMatch;
            }
            matches.Add(new TokenMatch { TokenType = TokenType.EndOfSequence });
            return matches;
        }

        private IEnumerable<TokenMatch> FindTokenMatches(string text)
        {
            var matches = new List<TokenMatch>();
            foreach (var tokenDefinition in _tokenDefinitions)
            {
                var tokenMatches = tokenDefinition.FindMatches(text);
                matches.AddRange(tokenMatches);
            }
            return matches;
        }
    }
}