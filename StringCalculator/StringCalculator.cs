using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    public class StringCalculator
    {
        public int Add(string numbersToAdd)
        {
            int total = 0;

            if (!String.IsNullOrWhiteSpace(numbersToAdd))
            {
                string[] splitNumbers = numbersToAdd.Split(',', '\n');

                foreach (var item in splitNumbers)
                {
                    total += Convert.ToInt32(item);
                }
            }

            return total;
        }
    }
}
