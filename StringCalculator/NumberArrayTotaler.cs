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

            ValidateNegativeNumbersDoNotExist(numbers);

            return numbers.Sum(n => String.IsNullOrWhiteSpace(n) ? 0 : ParseStringToInteger(n));
        }

        private void ValidateNegativeNumbersDoNotExist(string[] numbers)
        {
            var negativeNumbers = numbers.Where(num => num.StartsWith("-"))
                                         .Select(num => num).ToArray();

            if (negativeNumbers != null && negativeNumbers.Length > 0)
            {
                throw new Exception(String.Format("Negatives not allowed: {0}",
                                    String.Join(",", negativeNumbers)));
            }
        }

        private int ParseStringToInteger(string number)
        {
            int parsedValue = Convert.ToInt32(number);

            return parsedValue > 1000 ? 0 : parsedValue;
        }
    }
}
