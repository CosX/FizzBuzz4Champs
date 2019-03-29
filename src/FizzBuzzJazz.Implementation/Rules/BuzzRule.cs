using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;

namespace FizzBuzzJazz.Implementation.Rules
{
    public class BuzzRule : IRule
    {
        public string Output => "Buzz";
        public bool IsValid(int input)
        {
            return input % 5 == 0;
        }
    }
}