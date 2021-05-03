using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    abstract class CronDate
    {
        public static DateTime Now => DateTime.Now;

        public abstract int Value { get; }

        public string[] SplittedRule
        {
            get
            {
                return rule.Split(' ');
            }
        }

        protected string rule;

        public CronDate(string rule)
        {
            this.rule = rule;
        }
    }
}
