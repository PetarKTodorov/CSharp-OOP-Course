namespace P01.AsynchronousProgramming
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class Engine
    {
        public async Task RunAsync()
        {
            //Console.Write("Enter a number: ");
            //int endNumber = int.Parse(Console.ReadLine());

            //PrintNumbersInRange(1, endNumber);

            //var task = Task.Run(() => PrintNumbersInRange(endNumber, endNumber + 20));

            //Console.WriteLine("Done.");

            //task.GetAwaiter().GetResult();

            int contentLength = await GetUrlContentLengthAsync();

            Console.WriteLine(contentLength);
        }

        private static void PrintNumbersInRange(int startNumber, int endNumber)
        {
            for (int number = startNumber; number <= endNumber; number++)
            {
                Console.WriteLine(number);
            }
        }

        private static async Task<int> GetUrlContentLengthAsync()
        {
            var client = new HttpClient();

            Task<string> getStringTask1 = client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");

            PrintNumbersInRange(10, 15);

            string contents = await getStringTask1;

            return contents.Length;
        }

    }
}
