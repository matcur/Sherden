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

                int value = new Year(rule).Value;
                int value1 = new Month(rule).Value;
                int value2 = new Day(rule).Value;
                int value3 = new Hour(rule).Value;
                int value4 = new Minute(rule).Value;
                int value5 = new Second(rule).Value;

                Console.WriteLine("s:{0}, m:{1}, h:{2}, d:{3}, M:{4}, Y:{5}", value5, value4, value3, value2, value1, value);

                return new DateTime(
                    value, value1, value2,
                    value3, value4, value5
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
