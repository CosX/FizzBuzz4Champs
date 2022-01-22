namespace FizzBuzzJazz.Rules;

public class JazzRule : IRule
{
    public RuleKey Key => RuleKey.Jazz;
    public string Output => "Jazz";
    public bool IsValid(int input) => input % 9 == 0;
}