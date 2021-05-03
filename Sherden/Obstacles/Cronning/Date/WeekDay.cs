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
                if (!HasPosition())
                    throw new ArgumentException("Day of week must be set");

                var stringDay = SplittedRule[RulePosition];
                if (stringDay == "*" || stringDay == "?")
                    return PrepareResult(Now.Day);

                var closeWeekDayDate = ParseCloseDateByWeekDay(stringDay);

                return PrepareResult(closeWeekDayDate.Day);
            }
        }

        public WeekDay(string rule) : base(rule) { }

        public bool HasPosition()
        {
            return SplittedRule.Length > RulePosition
                && SplittedRule[RulePosition] != "?";
        }

        public DateTime ParseCloseDateByWeekDay(string stringDay)
        {
            DayOfWeek day;
            if (!Enum.TryParse(stringDay, out day))
                throw new ArgumentException($"Day of week must be number, ? or *, [{stringDay}] given");

            var result = DateTime.Now;
            while (result.DayOfWeek != day)
                result = result.AddDays(1);

            return result;
        }

        private int PrepareResult(int day)
        {
            if (IsHourOver(day))
                day += 7;

            return day;
        }
    }
}