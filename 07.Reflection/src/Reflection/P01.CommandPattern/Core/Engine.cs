namespace P01.CommandPattern.Core
{
    using System;

    using P01.CommandPattern.Core.Interfaces;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string commandLine = Console.ReadLine();

                string result = commandInterpreter.Read(commandLine);

                Console.WriteLine(result);
            }
        }
    }
}
