namespace P01.CommandPattern
{
    using P01.CommandPattern.Core;
    using P01.CommandPattern.Core.Interfaces;

    public class StartUp
    {
        internal static void Main()
        {
            ICommandInterpreter command = new CommandInterpreter();
            IEngine engine = new Engine(command);

            engine.Run();
        }
    }
}
