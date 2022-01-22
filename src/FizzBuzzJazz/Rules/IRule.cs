namespace FizzBuzzJazz.Rules;

public interface IRule
{
    string Output { get; }
    bool IsValid(int input);
}