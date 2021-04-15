namespace P03.ExerciseFactoryPattern.Core
{
    using System;
    using System.Text;
    using System.Linq;

    using P03.ExerciseFactoryPattern.Core.Controllers;
    using P03.ExerciseFactoryPattern.Core.Controllers.Interfaces;
    using P03.ExerciseFactoryPattern.Core.Interfaces;

    public class Engine : IEngine
    {
        private const string FINISH_COMMAND = "Finish";
        private const string CREATE_COMMAND = "Create";

        private IController instrumentController;
        private StringBuilder stringBuilder;

        public Engine()
        {
            this.instrumentController = new InstrumentController();
            this.stringBuilder = new StringBuilder();
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != FINISH_COMMAND)
            {
                string result = String.Empty;
                string[] arguments = input.Split(' ');

                string command = arguments.First();
                string instrumentType = arguments.Skip(1).Take(1).ToArray().First();

                switch (command)
                {
                    case CREATE_COMMAND:
                            result = this.instrumentController.Create(instrumentType); 
                        break;
                }

                this.stringBuilder.AppendLine(result);
            }

            string finalResult = this.stringBuilder.ToString();
            Console.WriteLine(finalResult);
        }
    }
}
