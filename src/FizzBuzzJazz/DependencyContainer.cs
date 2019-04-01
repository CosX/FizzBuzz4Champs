using System;
using System.Collections.Generic;
using System.Linq;
using FizzBuzzJazz.Implementation;
using FizzBuzzJazz.Implementation.Rules;
using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FizzBuzzJazz.Console
{
    public static class DependencyContainer
    {
        public static ServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
                .AddTransient<IRule, FizzRule>()
                .AddTransient<IRule, BuzzRule>()
                .AddTransient<IRule, JazzRule>()
                .AddTransient<IRule, FuzzRule>()
                .AddTransient(
                    factory => (Func<RuleKey, IRule>)
                        (key => factory.GetServices<IRule>().FirstOrDefault(m => m.Key == key)
                    ))
                .AddTransient<IGameService, GameService>()
                .AddTransient<DirectionGenerator>()
                .BuildServiceProvider();
        }
    }
}
