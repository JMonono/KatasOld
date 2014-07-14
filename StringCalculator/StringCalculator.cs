using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        private readonly string _CUSTOM_DELIMITER_PATTERN = "\\";
        private INumberArrayTotaler _numberTotaler;

        public StringCalculator(INumberArrayTotaler numberTotaler)
        {
            if (numberTotaler == null)
            {
                throw new ArgumentNullException("numberTotaler");
            }

            this._numberTotaler = numberTotaler;
        }

        public int Add(string numbersToAdd)
        {
            return
                String.IsNullOrWhiteSpace(numbersToAdd) ? 0 : GetSumOfNumbers(numbersToSum: numbersToAdd);
        }

        private int GetSumOfNumbers(string numbersToSum)
        {
            string[] parsedNumbers = ParseNumberString(numbersToSum);

            return _numberTotaler.Total(parsedNumbers);
        }

        private string[] ParseNumberString(string numbersToSum)
        {
            string delimitersToUse = GetDefaultDelimiters();
            string numbersToParse = numbersToSum;

            // parse numbers
            if (HasCustomDelimiter(numbersToParse))
            {
                delimitersToUse = GetCustomDelimiter(numbersToParse);
                numbersToParse = GetNumbersFromStringWithCustomDelimiter(numbersToParse);
            }

            return numbersToParse.Split(delimitersToUse.ToCharArray());
        }

        private string GetDefaultDelimiters()
        {
            return ",\n";
        }

        private string GetNumbersFromStringWithCustomDelimiter(string numbersToSum)
        {
            return numbersToSum.Substring(numbersToSum.IndexOf('\n') + 1);
        }

        private string GetCustomDelimiter(string numbersToSum)
        {
            var delimiterEndIndex = numbersToSum.IndexOf('\n');
            return numbersToSum.Substring(1, (delimiterEndIndex - 1));
        }

        private bool HasCustomDelimiter(string numbersToSum)
        {
            return numbersToSum.StartsWith(_CUSTOM_DELIMITER_PATTERN);
        }
    }
}
