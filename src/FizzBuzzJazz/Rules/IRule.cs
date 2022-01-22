namespace FizzBuzzJazz.Rules;

public interface IRule
{
    RuleKey Key { get; }
    string Output { get; }
    bool IsValid(int input);
}