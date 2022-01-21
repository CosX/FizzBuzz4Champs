namespace FizzBuzzJazz.Rules;

public class BuzzRule : IRule
{
    public string Output => "Buzz";
    public bool IsValid(int input) => input % 5 == 0;
}