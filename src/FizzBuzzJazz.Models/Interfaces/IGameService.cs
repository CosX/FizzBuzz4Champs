using System.Collections.Generic;
using FizzBuzzJazz.Models.Enums;

namespace FizzBuzzJazz.Models.Interfaces
{
    public interface IGameService
    {
        void LoadRules(params RuleKey[] keys);
        void DisposeRules();
        IEnumerable<string> GetResults(int from, int to);
    }
}
