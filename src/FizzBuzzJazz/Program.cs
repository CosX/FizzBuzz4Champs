using System;
using System.Collections.Generic;
using FizzBuzzJazz.Implementation;
using FizzBuzzJazz.Implementation.Rules;
using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzzJazz.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddTransient<FizzRule>()
                .AddTransient<BuzzRule>()
                .AddTransient<JazzRule>()
                .AddTransient<FuzzRule>()
                .AddTransient(factory =>
                {
                    return (Func<RuleKey, IRule>)(key =>
                    {
                        switch (key)
                        {
                            case RuleKey.Fizz:
                                return factory.GetService<FizzRule>();
                            case RuleKey.Buzz:
                                return factory.GetService<BuzzRule>();
                            case RuleKey.Jazz:
                                return factory.GetService<JazzRule>();
                            case RuleKey.Fuzz:
                                return factory.GetService<FuzzRule>();
                            default:
                                throw new KeyNotFoundException();
                        }
                    });
                })
                .AddTransient<IGameService, GameService>()
                .AddTransient<DirectionGenerator>()
                .BuildServiceProvider();

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
