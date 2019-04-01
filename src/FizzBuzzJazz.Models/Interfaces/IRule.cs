using FizzBuzzJazz.Models.Enums;

namespace FizzBuzzJazz.Models.Interfaces
{
    public interface IRule
    {
        RuleKey Key { get; }
        string Output { get; }
        bool IsValid(int input);
    }
}
