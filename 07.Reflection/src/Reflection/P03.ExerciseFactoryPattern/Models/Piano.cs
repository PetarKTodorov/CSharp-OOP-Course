using System;
using System.Collections.Generic;
using System.Text;

namespace P03.ExerciseFactoryPattern.Models
{
    public class Piano : Instrument
    {
        private const int REPAIER_AMOUNT = 80;

        protected override int RepairAmount => REPAIER_AMOUNT;
    }
}
