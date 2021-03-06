﻿using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;

namespace FizzBuzzJazz.Implementation.Rules
{
    public class JazzRule : IRule
    {
        public RuleKey Key => RuleKey.Jazz;
        public string Output => "Jazz";
        public bool IsValid(int input) => input % 9 == 0;
    }
}