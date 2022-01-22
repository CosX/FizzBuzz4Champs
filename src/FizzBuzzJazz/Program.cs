using System;
using System.Linq;
using FizzBuzzJazz;
using FizzBuzzJazz.Rules;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddTransient<IRule, FizzRule>()
    .AddTransient<IRule, BuzzRule>()
    .AddTransient<IRule, JazzRule>()
    .AddTransient<IRule, FuzzRule>()
    .AddTransient<Game>()
    .AddTransient(
        factory => (Func<RuleKey, IRule>)
            (key => factory.GetServices<IRule>().FirstOrDefault(m => m.Key == key))
    )
    .BuildServiceProvider();

var engine = serviceProvider.GetService<Game>();

engine!.LoadRules(RuleKey.Fizz, RuleKey.Buzz);

foreach (var result in engine.GetResults(1, 100))
    Console.WriteLine(result);

engine.DisposeRules();

Console.ReadKey();

engine.LoadRules(RuleKey.Jazz, RuleKey.Fuzz);

foreach (var result in engine.GetResults(1, 100))
    Console.WriteLine(result);

engine.DisposeRules();

Console.ReadKey();

serviceProvider.Dispose();