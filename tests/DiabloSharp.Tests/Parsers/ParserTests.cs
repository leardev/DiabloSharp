using System;
using DiabloSharp.Parsers;
using NUnit.Framework;

namespace DiabloSharp.Tests.Parsers
{
    [TestFixture]
    public class ParserTests
    {
        [Test]
        public void ParseTest()
        {
            var example = $"+100 Dexterity{Environment.NewLine}" +
                          $"+200 Strength{Environment.NewLine}" +
                          $"+300 Intelligence{Environment.NewLine}" +
                          $"+400 Vitality{Environment.NewLine}" +
                          $"Attack Speed Increased by 7.0%{Environment.NewLine}" +
                          $"Critical Hit Chance Increased by 6.0%{Environment.NewLine}" +
                          $"Reduces cooldown of all skills by 8.0%.{Environment.NewLine}" +
                          $"+360 Strength (Caldesann's Despair Rank 72)";

            var tokenizer = new Tokenizer();
            var tokens = tokenizer.Tokenize(example);

            var parser = new Parser();
            var attributes = parser.Parse(tokens);
        }
    }
}