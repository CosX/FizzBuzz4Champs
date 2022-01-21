using FizzBuzzJazz.Rules;
using Xunit;

namespace FizzBuzzJazz.Tests;

public class RuleTests
{
    private static JazzRule _jazzRule;
    private static FizzRule _fizzRule;
    private static BuzzRule _buzzRule;
    private static FuzzRule _fuzzRule;

    public RuleTests()
    {
        _buzzRule = new BuzzRule();
        _fizzRule = new FizzRule();
        _fuzzRule = new FuzzRule();
        _jazzRule = new JazzRule();
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(5, true)]
    public void BuzzRule_IsValid(int input, bool expected)
    {
        Assert.Equal(expected, _buzzRule.IsValid(input));
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(3, true)]
    public void FizzRule_IsValid(int input, bool expected)
    {
        Assert.Equal(expected, _fizzRule.IsValid(input));
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(9, true)]
    public void JazzRule_IsValid(int input, bool expected)
    {
        Assert.Equal(expected, _jazzRule.IsValid(input));
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(4, true)]
    public void FuzzRule_IsValid(int input, bool expected)
    {
        Assert.Equal(expected, _fuzzRule.IsValid(input));
    }
}