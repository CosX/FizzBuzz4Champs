using System.Collections.Generic;
using System.Linq;
using FizzBuzzJazz.Rules;
using Xunit;

namespace FizzBuzzJazz.Tests;

public class GameTests
{
    private readonly Game _sut;

    public GameTests()
    {
        IRule MockFunc(RuleKey key)
        {
            return key switch
            {
                RuleKey.Fizz => new FizzRule(),
                _ => throw new KeyNotFoundException()
            };
        }

        _sut = new Game(MockFunc);
    }

    [Fact]
    public void Game_CountsForwards()
    {
        IEnumerable<string> results = _sut.GetResults(1, 2).ToList();

        Assert.Equal("1" ,results.ElementAtOrDefault(0));
        Assert.Equal("2", results.ElementAtOrDefault(1));
    }

    [Fact]
    public void Game_RulePrintsFizz()
    {
        _sut.LoadRules(RuleKey.Fizz);
        IEnumerable<string> results = _sut.GetResults(3, 5).ToList();
        Assert.Equal("Fizz", results.FirstOrDefault());
        Assert.Equal(3, results.Count());
    }
}