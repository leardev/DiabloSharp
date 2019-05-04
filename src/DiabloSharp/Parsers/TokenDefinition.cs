using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DiabloSharp.Parsers
{
    internal class TokenDefinition
    {
        private readonly Regex _regex;

        private readonly TokenType _returnsToken;

        private readonly int _precedence;

        public TokenDefinition(TokenType returnsToken, string regexPattern, int precedence)
        {
            _regex = new Regex(regexPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.Multiline);
            _returnsToken = returnsToken;
            _precedence = precedence;
        }

        public IEnumerable<TokenMatch> FindMatches(string inputString)
        {
            var regexMatches = _regex.Matches(inputString);

            var matches = new List<TokenMatch>();
            foreach (Match regexMatch in regexMatches)
            {
                var match = new TokenMatch
                {
                    StartIndex = regexMatch.Index,
                    EndIndex = regexMatch.Index + regexMatch.Length,
                    TokenType = _returnsToken,
                    Value = regexMatch.Value,
                    Precedence = _precedence
                };
                matches.Add(match);
            }

            return matches;
        }
    }
}