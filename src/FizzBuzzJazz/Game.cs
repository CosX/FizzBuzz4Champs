using System.Collections.Generic;
using System.Linq;
using FizzBuzzJazz.Rules;

namespace FizzBuzzJazz;

public class Game
{
    private readonly IEnumerable<IRule> _rules;
    public Game(IEnumerable<IRule> rules) =>
        _rules = rules;

    public IEnumerable<string> GetResults(int from, int to)
    {
        foreach (var i in Enumerable.Range(from, to - ( from -1 )))
        {
            var output = _rules
                .Where(rule => rule.IsValid(i))
                .Aggregate(string.Empty, (current, rule) => current + rule.Output);

            if (string.IsNullOrEmpty(output))
                output = i.ToString();

            yield return output;
        }
    }
}