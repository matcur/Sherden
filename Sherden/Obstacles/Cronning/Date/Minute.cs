using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    class Minute : CronDate
    {
        public const int RulePosition = 1;

        public override int Value
        {
            get
            {
                var stringMinute = SplittedRule[RulePosition];
                if (stringMinute == "*")
                    return PrepareResult(Now.Minute);

                int minute;
                if (!int.TryParse(stringMinute, out minute))
                    throw new ArgumentException($"Second must be number or *, [{stringMinute}] given");

                return PrepareResult(minute);
            }
        }

        public Minute(string rule) : base(rule) { }

        public bool IsSecondOver(int minute)
        {
            return new Second(rule).Value < Now.Second
                 && Now.Minute >= minute;
        }

        private int PrepareResult(int minute)
        {
            if (minute > 60 || minute < 0)
                throw new ArgumentException($"Second must be between [0, 60], [{minute}] given");

            if (IsSecondOver(minute))
                minute++;

            return minute;
        }
    }
}
