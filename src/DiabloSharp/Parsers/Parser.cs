using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DiabloSharp.Helpers;
using DiabloSharp.Models;

namespace DiabloSharp.Parsers
{
    internal class Parser
    {
        private readonly Stack<TokenMatch> _tokens;

        private TokenMatch _lookaheadFirst;

        private TokenMatch _lookaheadSecond;

        private List<IHeroItemAttribute> _attributes;

        public Parser()
        {
            _tokens = new Stack<TokenMatch>();
        }

        public IEnumerable<IHeroItemAttribute> Parse(IEnumerable<TokenMatch> tokens)
        {
            _attributes = new List<IHeroItemAttribute>();
            LoadSequenceStack(tokens);
            PrepareLookaheads();
            Match();
            return _attributes;
        }

        private void Match()
        {
            while (_lookaheadFirst.TokenType != TokenType.EndOfSequence)
            {
                switch (_lookaheadFirst.TokenType)
                {
                    case TokenType.Plus:
                        MatchPlus();
                        break;
                    case TokenType.Value:
                        break;
                    case TokenType.Percent:
                    case TokenType.Text:
                    case TokenType.EndOfLine:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                NextLine();
            }
        }

        private void MatchPlus()
        {
            Expect(TokenType.Plus);
            NextToken();

            Expect(TokenType.Value);
            var value = double.Parse(_lookaheadFirst.Value, CultureInfo.InvariantCulture);
            NextToken();

            Expect(TokenType.Text);
            var attributeId = EnumConversionHelper.HeroItemAttributeIdFromString(_lookaheadFirst.Value);
            NextToken();

            if (_lookaheadFirst.TokenType == TokenType.EndOfLine)
                MatchPrimaryStat(value, attributeId);
        }

        private void MatchPrimaryStat(double value, HeroItemAttributeId attributeId)
        {
            var attribute = new HeroItemAttribute
            {
                Id = attributeId,
                Value = value
            };
            _attributes.Add(attribute);
        }

        private void Expect(TokenType token)
        {
            if (_lookaheadFirst.TokenType != token)
                throw new Exception($"Expected token {token} but got {_lookaheadFirst.TokenType}.");
        }

        private void LoadSequenceStack(IEnumerable<TokenMatch> tokens)
        {
            foreach (var token in tokens.Reverse())
                _tokens.Push(token);
        }

        private void PrepareLookaheads()
        {
            _lookaheadFirst = _tokens.Pop();
            _lookaheadSecond = _tokens.Pop();
        }

        private string ReadTextTokens()
        {
            var text = string.Empty;
            while (_lookaheadFirst.TokenType == TokenType.Text)
            {
                text = $"{text} {_lookaheadFirst.Value}";
                NextToken();
            }
            return text;
        }

        private void NextToken()
        {
            _lookaheadFirst = _lookaheadSecond;

            _lookaheadSecond = null;
            if (_tokens.Count != 0)
                _lookaheadSecond = _tokens.Pop();
        }

        private void NextLine()
        {
            while (_lookaheadFirst.TokenType != TokenType.EndOfLine)
                NextToken();
            NextToken();
        }
    }
}