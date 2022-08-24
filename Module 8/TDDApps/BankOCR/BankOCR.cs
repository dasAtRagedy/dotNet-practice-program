using System;

namespace BankOCR;

public class BankOcr
{
    private string[] _digits = new[]
    {
        " _ "+
        "| |"+
        "|_|", 

        "   "+
        "  |"+
        "  |",

        " _ "+
        " _|"+
        "|_ ",
 
        " _ "+
        " _|"+
        " _|",
 
        "   "+
        "|_|"+
        "  |",
 
        " _ "+
        "|_ "+
        " _|",
 
        " _ "+
        "|_ "+
        "|_|",
 
        " _ "+
        "  |"+
        "  |",
 
        " _ "+
        "|_|"+
        "|_|",
 
        " _ "+
        "|_|"+
        " _|"
    };

    public string Parse(string input)
    {
        string result = "";
        bool found;
        for (int i = 0; i < 9; i++)
        {
            found = false;
            for(int j = 0; j < _digits.Length; j++)
            {
                var currentDigit = string.Concat(input.AsSpan(i*3, 3), 
                                                      input.AsSpan(27+i*3, 3), 
                                                      input.AsSpan(27*2+i*3, 3));
                if (currentDigit != _digits[j]) continue;
                result += j.ToString();
                found = true;
                break;
            }
            if (!found) 
                result += '?';
        }
        
        return result;
    }
    
    public static bool IsSumValid(string input)
    {
        int result = 0;
        for (int i = 0; i < 9; i++)
        {
            result += (input[i] - '0') * (9 - i);
        }

        return result % 11 == 0;
    }
}
