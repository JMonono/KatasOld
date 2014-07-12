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
        private readonly int _CUSTOM_DELIMITER_PLUS_ONE_INDEX = 3;
        private INumberArrayTotaler _numberTotaler;
        private INumberStringParser _numberParser;

        public StringCalculator(INumberStringParser numberParser, INumberArrayTotaler numberTotaler)
        {
            if (numberParser == null)
            {
                throw new ArgumentNullException("numberParser");
            }

            if (numberTotaler == null)
            {
                throw new ArgumentNullException("numberTotaler");
            }

            // TODO: Complete member initialization
            this._numberParser = numberParser;
            this._numberTotaler = numberTotaler;
        }

        public int Add(string numbersToAdd)
        {
            string[] splitNumbers = null;
            char customDelimiter;

            // Guard for empty string
            if (String.IsNullOrWhiteSpace(numbersToAdd))
                return 0;

            // parse numbers
            if (numbersToAdd.StartsWith(_CUSTOM_DELIMITER_PATTERN))
            {
                customDelimiter = numbersToAdd.ToCharArray(1, 1)[0];
                numbersToAdd = numbersToAdd.Substring(_CUSTOM_DELIMITER_PLUS_ONE_INDEX);

                splitNumbers = _numberParser.Parse(numberString: numbersToAdd,
                                               additionalDelimiters: new List<char>() { customDelimiter });
            }
            else
            {
                // sum numbers
                splitNumbers = _numberParser.Parse(numberString: numbersToAdd);
            }

            return _numberTotaler.Total(splitNumbers);
        }
    }
}
