using System;

namespace Sherden.Obstacles.Cronning.Date
{
    class WeekDay : Day
    {
        public const int RulePosition = 3;

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

                return ParseCloseDate(stringDay).Day;
            }
        }

        public WeekDay(string rule) : base(rule) { }

        public bool HasPosition()
        {
            return SplittedRule.Length > RulePosition
                && SplittedRule[RulePosition] != "?";
        }

        private DateTime ParseCloseDate(string stringDay)
        {
            DayOfWeek day;
            if (!Enum.TryParse(stringDay, out day))
                throw new ArgumentException($"Day of week must be number, ? or *, [{stringDay}] given");

            var result = DateTime.Now;
            while (result.DayOfWeek != day)
                result = result.AddDays(1);

            return result;
        }
    }
}