using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class NumberArrayTotaler : INumberArrayTotaler
    {
        public int Total(string[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            return numbers.Sum(n => Convert.ToInt32(n));
        }
    }
}
