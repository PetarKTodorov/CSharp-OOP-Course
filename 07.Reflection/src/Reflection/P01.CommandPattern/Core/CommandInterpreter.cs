namespace P01.CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using P01.CommandPattern.Core.Interfaces;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_SUFFIX = "Command";

        public string Read(string inputLine)
        {
            string[] cmdTokens = inputLine.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string commandName = cmdTokens[0] + COMMAND_SUFFIX;
            string[] commandArgs = cmdTokens.Skip(1).ToArray();

            var assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();

            Type typeToCreate = types.FirstOrDefault(type => type.Name == commandName && type.GetInterfaces().Contains(typeof(ICommand)));

            bool isNull = typeToCreate == null;
            if (isNull)
            {
                throw new InvalidOperationException("Invalid Command Type!");
            }

            Object instance = Activator.CreateInstance(typeToCreate);

            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;

        }
    }
}
