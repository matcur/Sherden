using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    class Year : CronDate
    {
        public const int RulePosition = 6;

        public override int Value
        {
            get
            {
                if (!HasYearPosition())
                    return DateTime.Now.Year;

                var stringYear = SplittedRule[RulePosition];
                if (stringYear == "*")
                    return DateTime.Now.Year;

                int year;
                if (!int.TryParse(stringYear, out year))
                    throw new ArgumentException($"Year must be number or *, [{stringYear}] given");

                if (IsMonthOver())
                    year++;

                return year;
            }
        }

        public Year(string rule): base(rule) { }

        public bool IsMonthOver()
        {
            return new Month(rule).Value < DateTime.Now.Month;
        }

        public bool HasYearPosition()
        {
            return SplittedRule.Length > RulePosition;
        }
    }
}
