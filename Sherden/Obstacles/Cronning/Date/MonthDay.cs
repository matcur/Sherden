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
                var stringDay = SplittedRule[RulePosition];
                if (stringDay == "*" || stringDay == "?")
                {
                    var result = Now.Day;
                    if (IsHourOver())
                        result = Now.AddDays(1).Day;

                    return result;
                }


                return TryParse(stringDay);
            }
        }

        public MonthDay(string rule) : base(rule) { }

        public bool HasPosition()
        {
            return SplittedRule.Length > RulePosition
                && SplittedRule[RulePosition] != "?";
        }

        private int TryParse(string stringDay)
        {
            int day;
            if (!int.TryParse(stringDay, out day))
                throw new ArgumentException($"Day must be number or *, [{stringDay}] given");

            return day;
        }
    }
}
