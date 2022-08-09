using System;
using System.Text.RegularExpressions;

namespace Task2
{
    public class NumberParser : INumberParser
    {
        public int Parse(string stringValue)
        {
            if (stringValue == null)
                throw new ArgumentNullException();
            if (string.IsNullOrWhiteSpace(stringValue))
                throw new FormatException();
            
            stringValue = Regex.Replace(stringValue, @"\s+", "");
            
            int result = 0;
            int power = 1;
            for (int i = stringValue.Length - 1; i >= 0; i--)
            {
                if ((stringValue[i] == '+' || stringValue[i] == '-') && i == 0)
                    continue;
                if (char.IsDigit(stringValue[i]))
                {
                    checked
                    {
                        if(stringValue[0] == '-')
                            result -= power * (stringValue[i] - '0');
                        else
                            result += power * (stringValue[i] - '0');
                    }
                    power *= 10;
                }
                else
                {
                    throw new FormatException("String contains non-digit characters");
                }
            }
            return result;
        }
    }
}