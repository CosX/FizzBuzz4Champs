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

        public GameService(Func<RuleKey, IRule> ruleAccessor)
        {
            _ruleAccessor = ruleAccessor;
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

        public IEnumerable<string> GetResults(int from, int to, Direction direction = Direction.Forwards)
        {
            for (int i = from; ValidateIterator(to, i, direction); AppendToIterator(ref i, direction))
            {
                string output = _rules
                    .Where(rule => rule.IsValid(i))
                    .Aggregate(string.Empty, (current, rule) => current + rule.Output);

                if (string.IsNullOrEmpty(output))
                    output = i.ToString();

                yield return output;
            }
        }

        private static bool ValidateIterator(int to, int i, Direction direction)
        {
            return direction == Direction.Forwards ? 
                i <= to :
                i >= to;
        }

        private static int AppendToIterator(ref int i, Direction direction)
        {
            return direction == Direction.Forwards ? 
                i++ : 
                i--;
        }
    }
}
