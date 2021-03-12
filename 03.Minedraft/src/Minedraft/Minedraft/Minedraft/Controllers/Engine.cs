namespace Minedraft.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Engine
    {
        public static void Run()
        {
            var draftManager = new DraftManager();
            string result = string.Empty;

            string input;
            while ((input = Console.ReadLine()) != "Shutdown")
            {
                List<string> arguments = input.Split(' ').ToList();

                string command = arguments[0];
                arguments = arguments.Skip(1).ToList();

                switch (command)
                {
                    case "RegisterHarvester": result = draftManager.RegisterHarvester(arguments); break;
                    case "RegisterProvider": result = draftManager.RegisterProvider(arguments); break;
                    case "Day": result = draftManager.Day(); break;
                    case "Mode": result = draftManager.Mode(arguments); break;
                    case "Check": result = draftManager.Check(arguments); break;
                }

                Console.WriteLine(result);
            }

            result = draftManager.ShutDown();

            Console.WriteLine(result);
        }
    }
}
