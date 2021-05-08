using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    class Day : CronDate
    {
        public override int Value
        {
            get
            {
                var monthDay = new MonthDay(rule);
                if (monthDay.HasPosition())
                    return monthDay.Value;

                var weekDay = new WeekDay(rule);
                if (weekDay.HasPosition())
                    return weekDay.Value;

                throw new ArgumentException("Week day or month day must be set.");
            }
        }

        public Day(string rule): base(rule) { }

        public bool IsHourOver()
        {
            return new Hour(rule).Value <= Now.Hour &&
                   new Minute(rule).Value <= Now.Minute &&
                   new Second(rule).Value <= Now.Second;
        }
    }
}
