namespace GrandPrix.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Controllers;

    public static class Engine
    {
        public static void Run()
        {
            int numberOfLaps = int.Parse(Console.ReadLine());
            int trackLength = int.Parse(Console.ReadLine());

            RaceTower raceTower = new RaceTower();

            raceTower.SetTrackInfo(numberOfLaps, trackLength);

            while (!raceTower.IsRaceOver)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string commandType = commandArgs[0];

                List<string> methodArgs = commandArgs.Skip(1).ToList();

                switch (commandType)
                {
                    case "RegisterDriver":
                        raceTower.RegisterDriver(methodArgs);
                        break;

                    case "Leaderboard":
                        string leaderboard = raceTower.GetLeaderboard();

                        Console.WriteLine(leaderboard);
                        break;

                    case "Box":
                        raceTower.DriverBoxes(methodArgs);
                        break;

                    case "CompleteLaps":
                        string result = raceTower.CompleteLaps(methodArgs);

                        if (!string.IsNullOrWhiteSpace(result))
                        {
                            Console.WriteLine(result);
                        }
                        break;

                    case "ChangeWeather":
                        raceTower.ChangeWeather(methodArgs);
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }
    }
}
