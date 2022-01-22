using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzJazz.Rules;

namespace FizzBuzzJazz;

public class Game
{
    private readonly Func<RuleKey, IRule> _ruleAccessor;
    private readonly IList<IRule> _rules = new List<IRule>();
    public Game(Func<RuleKey, IRule> ruleAccessor) =>
        _ruleAccessor = ruleAccessor;

    public void LoadRules(params RuleKey[] keys)
    {
        foreach (var ruleKey in keys)
            _rules.Add(_ruleAccessor(ruleKey));
    }

    public void DisposeRules() => _rules.Clear();

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