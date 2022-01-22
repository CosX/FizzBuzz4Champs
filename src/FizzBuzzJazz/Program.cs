using FizzBuzzJazz;
using FizzBuzzJazz.Rules;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddTransient<IRule, FizzRule>()
    .AddTransient<IRule, BuzzRule>()
    .AddTransient<IRule, JazzRule>()
    .AddTransient<IRule, FuzzRule>()
    .AddTransient<Game>()
    .BuildServiceProvider();;

var engine = serviceProvider.GetService<Game>();
foreach (var result in engine!.GetResults(1, 100))
    System.Console.WriteLine(result);

System.Console.ReadKey();