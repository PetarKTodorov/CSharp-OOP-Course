namespace P01.CommandPattern.Core.Commands
{
    using System;

    using P01.CommandPattern.Core.Interfaces;

    public class ExitCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Environment.Exit(0);

            return null;
        }
    }
}
