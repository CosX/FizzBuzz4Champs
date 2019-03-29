﻿using FizzBuzzJazz.Models.Enums;
using FizzBuzzJazz.Models.Interfaces;

namespace FizzBuzzJazz.Implementation.Rules
{
    public class FuzzRule : IRule
    {
        public string Output => "Fuzz";
        public bool IsValid(int input)
        {
            return input % 4 == 0;
        }
    }
}