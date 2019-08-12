using System;
using System.Collections.Generic;
using System.Text;

namespace calculajuros.domain.Helpers
{
    public static class Utils
    {
        public static decimal Power(this decimal num, int pwr)
        {
            Func<decimal, int, decimal> power = null;
            power = (i, p) => p == 1 ? i : i * power(i, p - 1);

            return power(num, pwr);
        }

        public static decimal Truncate(this decimal d, byte decimals)
        {
            decimal r = Math.Round(d, decimals);

            if (d > 0 && r > d)
            {
                return r - new decimal(1, 0, 0, false, decimals);
            }
            else if (d < 0 && r < d)
            {
                return r + new decimal(1, 0, 0, false, decimals);
            }

            return r;
        }
    }
}
