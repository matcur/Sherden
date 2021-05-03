using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    class MonthDay : Day
    {
        public const int RulePosition = 5;

        public override int Value
        {
            get
            {
                if (!HasPosition())
                    throw new ArgumentException("Day of month must be set");

                var stringDay = SplittedRule[RulePosition];
                if (stringDay == "*")
                    return DateTime.Now.Day;

                int day;
                if (!int.TryParse(stringDay, out day))
                    throw new ArgumentException($"Day must be number or *, [{stringDay}] given");

                if (IsHourOver(day))
                {
                    day++;
                }

                return day;
            }
        }

        public MonthDay(string rule) : base(rule) { }

        public bool HasPosition()
        {
            return SplittedRule.Length > RulePosition
                && SplittedRule[RulePosition] != "?";
        }
    }
}
