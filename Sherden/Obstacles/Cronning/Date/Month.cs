using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    class Month : CronDate
    {
        public const int RulePosition = 4;

        public override int Value
        {
            get
            {
                var stringMounth = SplittedRule[RulePosition];
                if (stringMounth == "*")
                {
                    var result = Now.Month;
                    if (IsDayOver())
                        result = Now.AddMonths(1).Month;

                    return result;
                }

                return TryParse(stringMounth);
            }
        }

        public Month(string rule) : base(rule) { }

        public bool IsDayOver()
        {
            return new Day(rule).Value <= Now.Day;
        }

        private int TryParse(string stringMounth)
        {
            int mounth;
            if (!int.TryParse(stringMounth, out mounth))
                throw new ArgumentException($"Month must be number or *, [{stringMounth}] given");

            if (mounth > 12 || mounth < 1)
                throw new ArgumentException($"Month must be between [1, 12], [{mounth}] given");

            return mounth;
        }
    }
}
