namespace P01.AsynchronousProgramming
{
    public class StartUp
    {
        public static void Main()
        {
            var engine = new Engine();

            engine.RunAsync().GetAwaiter().GetResult();
        }
    }
}
