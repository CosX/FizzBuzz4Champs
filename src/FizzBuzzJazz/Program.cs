using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzzJazz.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = DependencyContainer.BuildServiceProvider();

            IGameService engine = serviceProvider.GetService<IGameService>();

            engine.LoadRules(RuleKey.Fizz, RuleKey.Buzz);

            foreach (string result in engine.GetResults(1, 100))
                System.Console.WriteLine(result);

            engine.DisposeRules();

            System.Console.ReadKey();

            engine.LoadRules(RuleKey.Jazz, RuleKey.Fuzz);

            foreach (string result in engine.GetResults(100, 1))
                System.Console.WriteLine(result);

            engine.DisposeRules();

            System.Console.ReadKey();
        }
    }
}
