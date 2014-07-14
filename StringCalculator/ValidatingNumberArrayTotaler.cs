using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public class ValidatingNumberArrayTotaler : INumberArrayTotaler
    {
        private readonly int _MAX_NUMBER = 1000;
        private INumberArrayTotaler _numberTotaler;

        public ValidatingNumberArrayTotaler(INumberArrayTotaler numberTotaler)
        {
            if (numberTotaler == null)
            {
                throw new ArgumentNullException("numberTotaler");
            }

            // TODO: Complete member initialization
            this._numberTotaler = numberTotaler;
        }

        public int Total(string[] numbers)
        {
            if (IsEmptyArray(numbers))
            {
                return 0;
            }

            var filteredNumbers = RemoveValuesGreaterThanMax(numbers: numbers);

            CheckForNegativeNumbers(filteredNumbers);

            return _numberTotaler.Total(filteredNumbers);
        }

        private bool IsEmptyArray(string[] numbers)
        {
            return (numbers == null || numbers.Length == 0);
        }

        private string[] RemoveValuesGreaterThanMax(string[] numbers)
        {
            return numbers.Where(num => (ParseString(num) <= _MAX_NUMBER))
                          .ToArray();
        }

        private void CheckForNegativeNumbers(string[] numbers)
        {
            var negativeNumbers = numbers.Where(num => num.StartsWith("-"))
                                         .Select(num => num).ToArray();

            if (negativeNumbers != null && negativeNumbers.Length > 0)
            {
                throw new Exception(String.Format("Negatives not allowed: {0}",
                                    String.Join(",", negativeNumbers)));
            }
        }

        private int ParseString(string number)
        {
            return String.IsNullOrWhiteSpace(number) ? 0 : Int32.Parse(number);
        }
    }
}
