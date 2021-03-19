namespace GrandPrix.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text;

    using Constants;
    using Factories;
    using Models;
    using Models.Drivers;
    using Models.Tyres;
    using Models.Vehicles;
    using Models.Enums;

    public class RaceTower
    {
        private const string CRASH_MESSAGE = "Crashed";
        private const int LESS_BEHIND_SECONDS_NORMAL = 2;
        private const int LESS_BEHIND_SECONDS = 3;

        private TyreFactory tyreFactory;
        private DriverFactory driverFactory;
        private List<Driver> racingDrivers;
        private Stack<Driver> failedDrivers;
        private Track track;

        public RaceTower()
        {
            this.tyreFactory = new TyreFactory();
            this.driverFactory = new DriverFactory();
            this.racingDrivers = new List<Driver>();
            this.failedDrivers = new Stack<Driver>();
        }

        public bool IsRaceOver => this.track.CurrentLap == this.track.LapsNumber;

        public void SetTrackInfo(int lapsNumber, int trackLength)
        {
            this.track = new Track(lapsNumber, trackLength);
        }

        public void RegisterDriver(List<string> commandArgs)
        {
            try
            {
                string driverType = commandArgs[0];
                string driverName = commandArgs[1];

                int horsepower = int.Parse(commandArgs[2]);
                double fuelAmount = double.Parse(commandArgs[3]);

                string[] tyresArgs = commandArgs.Skip(4).ToArray();

                Tyre tyre = this.tyreFactory.Create(tyresArgs);

                Car car = new Car(horsepower, fuelAmount, tyre);

                Driver driver = this.driverFactory.Create(driverType, driverName, car);

                this.racingDrivers.Add(driver);
            }
            catch
            {
                // If you can’t create a Driver with the data provided upon this command just skip it.
            }
        }

        public void DriverBoxes(List<string> commandArgs)
        {
            string reasonToBox = commandArgs[0];
            string driverName = commandArgs[1];

            Driver driver = this.racingDrivers.SingleOrDefault(d => d.Name == driverName);

            string[] methodArgs = commandArgs.Skip(2).ToArray();

            if (reasonToBox == "Refuel")
            {
                driver.Reful(methodArgs);
            }
            else if (reasonToBox == "ChangeTyres") 
            {
                Tyre tyre = this.tyreFactory.Create(methodArgs);

                driver.ChangeTyres(tyre);
            }
        }

        public string CompleteLaps(List<string> commandArgs)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int numberOfLaps = int.Parse(commandArgs[0]);

            bool invalidLap = numberOfLaps > this.track.LapsNumber - this.track.CurrentLap;

            if (invalidLap)
            {
                try
                {
                    throw new ArgumentException(string.Format(OutputMessages.InvalidLaps, this.track.CurrentLap));
                }
                catch (ArgumentException ae)
                {
                    return ae.Message;
                }
            }

            for (int lap = 0; lap < numberOfLaps; lap++)
            {
                for (int index = 0; index < this.racingDrivers.Count; index++)
                {
                    Driver driver = racingDrivers[index];

                    try
                    {
                        driver.CompleteLap(this.track.TrackLength);
                    }
                    catch (ArgumentException ae)
                    {
                        driver.Fail(ae.Message);
                        this.failedDrivers.Push(driver);
                        this.racingDrivers.RemoveAt(index);
                        index--;
                    }
                }
            

                this.track.CurrentLap++;

                List<Driver> orderedDrivers = this.racingDrivers
                        .OrderByDescending(d => d.TotalTime)
                        .ToList();

                for (int index = 0; index < orderedDrivers.Count - 1; index++)
                {
                    Driver overtakingDriver = orderedDrivers[index];
                    Driver targetDriver = orderedDrivers[index + 1];

                    bool overTakeHappend = this.TryOverTake(overtakingDriver, targetDriver);

                    if (overTakeHappend)
                    {
                        index++;

                        stringBuilder.AppendLine(string.Format(
                            OutputMessages.OvertakeMessage,
                            overtakingDriver.Name,
                            targetDriver.Name,
                            this.track.CurrentLap));
                    }
                    else
                    {
                        if (!overtakingDriver.IsRacing)
                        {
                            this.failedDrivers.Push(overtakingDriver);
                            this.racingDrivers.Remove(overtakingDriver);
                        }
                    }
                }
            }

            if (this.IsRaceOver)
            {
                Driver winner = this.racingDrivers.OrderBy(d => d.TotalTime).First();

                stringBuilder.AppendLine(
                    string.Format(OutputMessages.WinnerMessage, winner.Name, winner.TotalTime)
                    );
            }

            string result = stringBuilder.ToString().TrimEnd();

            return result;
        }

        public string GetLeaderboard()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"Lap {this.track.CurrentLap}/{this.track.LapsNumber}");

            IEnumerable<Driver> drivers = this.racingDrivers
                 .OrderBy(d => d.TotalTime)
                 .Concat(this.failedDrivers);

            int position = 1;

            foreach (Driver driver in drivers)
            {
                stringBuilder.AppendLine($"{position} {driver.ToString()}");
                position++;
            }

            string leaderboard = stringBuilder.ToString().TrimEnd();

            return leaderboard;
        }

        public void ChangeWeather(List<string> commandArgs)
        {
            string weatherType = commandArgs[0];

            bool validWeather = Enum.TryParse<Weather>(weatherType, out Weather weather);

            if (!validWeather)
            {
                throw new ArgumentException(OutputMessages.InvalidWeatherType);
            }

            this.track.Weather = weather;
        }

        private bool TryOverTake(Driver overtakingDriver, Driver targetDriver)
        {
            double timeDiff = overtakingDriver.TotalTime - targetDriver.TotalTime;

            bool aggresiveDriver = overtakingDriver is AggressiveDriver
                && overtakingDriver.Car.Tyre is UltrasoftTyre;

            bool enduranceDriver = overtakingDriver is EnduranceDriver
                && overtakingDriver.Car.Tyre is HardTyre;

            bool crash = (aggresiveDriver && this.track.Weather == Weather.Foggy)
                || (enduranceDriver && this.track.Weather == Weather.Rainy);

            if ((aggresiveDriver || enduranceDriver) && timeDiff <= LESS_BEHIND_SECONDS)
            {
                if (crash)
                {
                    overtakingDriver.Fail(CRASH_MESSAGE);

                    return false;
                }
                overtakingDriver.TotalTime -= LESS_BEHIND_SECONDS;
                targetDriver.TotalTime += LESS_BEHIND_SECONDS;

                return true;
            }
            else if (timeDiff <= LESS_BEHIND_SECONDS_NORMAL)
            {
                overtakingDriver.TotalTime -= LESS_BEHIND_SECONDS_NORMAL;
                targetDriver.TotalTime += LESS_BEHIND_SECONDS_NORMAL;

                return true;
            }

            return false;
        }
    }
}
