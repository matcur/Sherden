using Sherden.Obstacles.Cronning.Date;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Sherden.Obstacles.Cronning
{
    class CronExpression
    {
        public TimeSpan ActivateTime => ActivateDate.AddMilliseconds(999) - DateTime.Now;

        public DateTime ActivateDate
        {
            // 0 0 0 DayOfMonth|? 1 DayOfWeek|? ?Year
            get
            {
                if (rule.Split(' ').Length < 6)
                    throw new ArgumentException("S, M, H, (DOW or DOM), M is required");

                int value = new Hour(rule).Value;
                int value1 = new Minute(rule).Value;
                int value2 = new Second(rule).Value;

                return new DateTime(
                    new Year(rule).Value, new Month(rule).Value, new Day(rule).Value,
                    value, value1, value2
                );
            }
        }

        private readonly string rule;

        public CronExpression(string rule)
        {
            this.rule = rule;
        }
    }
}
