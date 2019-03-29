using FizzBuzzJazz.Models.Enums;

namespace FizzBuzzJazz.Models.Interfaces
{
    public interface IRule
    {
        string Output { get; }
        bool IsValid(int input);
    }
}
