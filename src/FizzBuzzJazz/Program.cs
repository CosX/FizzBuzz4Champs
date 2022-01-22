using System.Linq;
using System.Reflection;
using FizzBuzzJazz;
using FizzBuzzJazz.Rules;
using Microsoft.Extensions.DependencyInjection;

var rules = Assembly.GetCallingAssembly().GetTypes()
    .Where(type => typeof(IRule).IsAssignableFrom(type) && !type.IsInterface);

var serviceCollection = new ServiceCollection()
    .AddTransient<Game>();

foreach (var rule in rules)
    serviceCollection.AddTransient(typeof(IRule), rule);

var serviceProvider = serviceCollection.BuildServiceProvider();

var engine = serviceProvider.GetService<Game>();
foreach (var result in engine!.GetResults(1, 100))
    System.Console.WriteLine(result);

System.Console.ReadKey();

serviceProvider.Dispose();