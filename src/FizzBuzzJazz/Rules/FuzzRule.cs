namespace FizzBuzzJazz.Rules;

public class FuzzRule : IRule
{
    public string Output => "Fuzz";
    public bool IsValid(int input) => input % 4 == 0;
}