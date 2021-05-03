using System;
using System.Collections.Generic;
using System.Text;

namespace Sherden.Obstacles.Cronning.Date
{
    class Second : CronDate
    {
        public const int RulePosition = 0;

        public override int Value
        {
            get
            {
                var stringSecond = SplittedRule[RulePosition];
                if (stringSecond == "*")
                    return GetAnySecond();

                return TryParseSecond(stringSecond);
            }
        }

        public Second(string rule) : base(rule) { }

        private int GetAnySecond()
        {
            var cronMinute = SplittedRule[Minute.RulePosition];
            if (cronMinute == Now.Minute.ToString() || cronMinute == "*")
                return Now.Second;

            return 0;
        }

        private int TryParseSecond(string stringSecond)
        {
            int second;
            if (!int.TryParse(stringSecond, out second))
                throw new ArgumentException($"Second must be number or *, [{stringSecond}] given");

            if (second > 60 || second < 0)
                throw new ArgumentException($"Second must be between [0, 60], [{second}] given");

            return second;
        }
    }
}
