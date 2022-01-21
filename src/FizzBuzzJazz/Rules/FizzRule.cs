namespace FizzBuzzJazz.Rules;

public class FizzRule : IRule
{
    public string Output => "Fizz";
    public bool IsValid(int input) => input % 3 == 0;
}