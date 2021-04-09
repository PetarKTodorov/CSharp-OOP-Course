namespace P01.CommandPattern.Core.Commands
{
    using P01.CommandPattern.Core.Interfaces;

    public class RegisterBusCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return "Register Bus";
        }
    }
}
