namespace P03.ExerciseFactoryPattern
{
    using P03.ExerciseFactoryPattern.Core;
    using P03.ExerciseFactoryPattern.Core.Interfaces;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}
