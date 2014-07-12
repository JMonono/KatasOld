using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringCalculator
{
    public interface INumberStringParser
    {
        string[] Parse(string numberString, List<char> additionalDelimiters = null);
    }
}
