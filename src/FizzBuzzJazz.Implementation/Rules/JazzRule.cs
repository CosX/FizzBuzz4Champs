using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;

namespace FizzBuzzJazz.Implementation.Rules
{
    public class JazzRule : IRule
    {
        public string Output => "Jazz";
        public bool IsValid(int input)
        {
            return input % 9 == 0;
        }
    }
}