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
                {
                    var result = Now.Minute;
                    if (IsSecondOver())
                        result = Now.AddMinutes(1).Minute;

                    return result;
                }

                return TryParse(stringMinute);
            }
        }

        public Minute(string rule) : base(rule) { }

        public bool IsSecondOver()
        {
            return new Second(rule).Value <= Now.Second;
        }

        private int TryParse(string stringMinute)
        {
            int minute;
            if (!int.TryParse(stringMinute, out minute))
                throw new ArgumentException($"Second must be number or *, [{stringMinute}] given");

            if (minute > 60 || minute < 0)
                throw new ArgumentException($"Second must be between [0, 60], [{minute}] given");

            return minute;
        }
    }
}
