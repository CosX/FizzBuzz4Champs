using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;

namespace FizzBuzzJazz.Implementation.Rules
{
    public class FuzzRule : IRule
    {
        public RuleKey Key => RuleKey.Fuzz;
        public string Output => "Fuzz";
        public bool IsValid(int input) => input % 4 == 0;
    }
}