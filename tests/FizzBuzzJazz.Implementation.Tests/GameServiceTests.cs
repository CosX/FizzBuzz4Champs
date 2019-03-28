using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzJazz.Implementation.Rules;
using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;
using Xunit;

namespace FizzBuzzJazz.Implementation.Tests
{
    public class GameServiceTests
    {
        private readonly GameService _sut;

        public GameServiceTests()
        {
            IRule MockFunc(RuleKey key)
            {
                switch (key)
                {
                    case RuleKey.Fizz:
                        return new FizzRule();
                    case RuleKey.Buzz:
                        return new BuzzRule();
                    case RuleKey.Jazz:
                        return new JazzRule();
                    case RuleKey.Fuzz:
                        return new FuzzRule();
                    default:
                        throw new KeyNotFoundException();
                }
            }

            _sut = new GameService(MockFunc);
        }

        [Fact]
        public void GameService_CountsForwards()
        {
            IEnumerable<string> results = _sut.GetResults(1, 2).ToList();

            Assert.Equal("1" ,results.ElementAtOrDefault(0));
            Assert.Equal("2", results.ElementAtOrDefault(1));
        }

        [Fact]
        public void GameService_CountsBackwards()
        {
            IEnumerable<string> results = _sut.GetResults(2, 1, Direction.Backwards).ToList();

            Assert.Equal("2", results.ElementAtOrDefault(0));
            Assert.Equal("1", results.ElementAtOrDefault(1));
        }
    }
}