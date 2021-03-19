namespace GrandPrix.Models
{
    using Enums;

    public class Track
    {
        private const int START_LAP = 0;

        public Track(int lapsNumber, int trackLength)
        {
            this.LapsNumber = lapsNumber;
            this.TrackLength = trackLength;
            this.Weather = Weather.Sunny;
            this.CurrentLap = START_LAP;
        }

        public int LapsNumber { get; }

        public int TrackLength { get; }

        public int CurrentLap { get; set; }

        public Weather Weather { get; set; }
    }
}
