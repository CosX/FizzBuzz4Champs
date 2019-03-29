using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;

namespace FizzBuzzJazz.Implementation.Rules
{
    public class FizzRule : IRule
    {
        public string Output => "Fizz";
        public bool IsValid(int input)
        {
            return input % 3 == 0;
        }
    }
}
