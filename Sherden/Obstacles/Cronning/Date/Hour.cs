using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    class Hour : CronDate
    {
        public const int RulePosition = 2;

        public override int Value
        {
            get
            {
                var stringHour = SplittedRule[RulePosition];
                if (stringHour == "*")
                {
                    var result = Now.Hour;
                    if (IsMinuteOver())
                        result = Now.AddHours(1).Hour;

                    return result;
                }

                return TryParse(stringHour);
            }
        }

        public Hour(string rule) : base(rule) { }

        public bool IsMinuteOver()
        {
            return new Minute(rule).Value <= Now.Minute;
        }

        private int TryParse(string stringHour)
        {
            int hour;
            if (!int.TryParse(stringHour, out hour))
                throw new ArgumentException($"Hour must be number or *, [{stringHour}] given");

            if (hour > 24 || hour < 1)
                throw new ArgumentException($"Hour must be between [1, 24], [{hour}] given");

            return hour;
        }
    }
}
