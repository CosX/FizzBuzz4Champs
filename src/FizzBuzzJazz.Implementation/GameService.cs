using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;

namespace FizzBuzzJazz.Implementation
{
    public class GameService : IGameService
    {
        private readonly Func<RuleKey, IRule> _ruleAccessor;
        private readonly IList<IRule> _rules = new List<IRule>();
        private readonly DirectionGenerator _directionGenerator;
        public GameService(Func<RuleKey, IRule> ruleAccessor, DirectionGenerator directionGenerator)
        {
            _ruleAccessor = ruleAccessor;
            _directionGenerator = directionGenerator;
        }

        public void LoadRules(params RuleKey[] keys)
        {
            foreach (RuleKey ruleKey in keys)
                _rules.Add(_ruleAccessor(ruleKey));
        }

        public void DisposeRules()
        {
            _rules.Clear();
        }

        public IEnumerable<string> GetResults(int from, int to)
        {
            foreach (int i in _directionGenerator.GetRange(from, to))
            {
                string output = _rules
                    .Where(rule => rule.IsValid(i))
                    .Aggregate(string.Empty, (current, rule) => current + rule.Output);

                if (string.IsNullOrEmpty(output))
                    output = i.ToString();

                yield return output;
            }
        }
    }
}
