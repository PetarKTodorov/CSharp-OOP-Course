namespace P01.CommandPattern.Core.Commands
{
    using P01.CommandPattern.Core.Interfaces;

    class RegisterCarCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return "Register Car";
        }
    }
}
