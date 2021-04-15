namespace P03.ExerciseFactoryPattern.Models
{
    using System;

    using P03.ExerciseFactoryPattern.Models.Interfaces;

    public abstract class Instrument : IInstrument
    {
		private const int MAX_WEAR = 100;
		private const int MIN_WEAR = 0;

		private double wear;

		protected Instrument()
		{
			this.Wear = MAX_WEAR;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
				this.wear = Math.Min(Math.Max(value, MIN_WEAR), MAX_WEAR);
			}
		}

		protected abstract int RepairAmount { get; }

		public bool IsBroken => this.Wear <= MIN_WEAR;

		public void Repair()
		{
			this.Wear += this.RepairAmount;
		}

		public void WearDown()
		{
			this.Wear -= this.RepairAmount;
		}

		public override string ToString()
		{
			string instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			string instrument = $"{this.GetType().Name} [{instrumentStatus}]";

			return instrument;
		}
	}
}
