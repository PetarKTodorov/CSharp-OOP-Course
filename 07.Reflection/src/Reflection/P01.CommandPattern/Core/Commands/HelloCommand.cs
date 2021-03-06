﻿namespace P01.CommandPattern.Core.Commands
{
    using P01.CommandPattern.Core.Interfaces;

    class HelloCommand : ICommand
    {
        public string Execute(string[] args)
        {
            string name = args[0];

            string result = $"Hi {name}";

            return result;
        }
    }
}
