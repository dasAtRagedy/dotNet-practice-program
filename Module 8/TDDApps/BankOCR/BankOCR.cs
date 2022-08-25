using System.Text;

namespace BankOCR;

public class BankOcr
{
    private readonly string[] _digits = {
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
        for (int i = 0; i < 9; i++)
        {
            var found = false;
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


    public string ParseWithCode(string input)
    {
        string result = Parse(input);
        int count = result.Count(f => f == '?');
        
        if (count >= 1)
            return result + " ILL";
        if(!IsSumValid(result))
            return result + " ERR";
        return result;
    }
    
    public string ParseWithCodeAndDeviations(string input)
    {
        string result = Parse(input);
        return FindDeviations(input, result);
    }

    private string FindDeviations(string rawInput, string parsedInput)
    {
        if(!parsedInput.Contains("?") && IsSumValid(parsedInput))
            return parsedInput;
        if (parsedInput.Count(f => f == '?') > 1)
            return parsedInput + " ILL";
        
        List<string> deviations = new List<string>();
        StringBuilder currentNumber = new StringBuilder(parsedInput);
        string digitToCheck;
        
        if (parsedInput.Count(f => f == '?') == 1)
        {
            int qIndex = parsedInput.IndexOf('?');
            digitToCheck = string.Concat(rawInput.AsSpan(qIndex * 3, 3),
                                                rawInput.AsSpan(27 + qIndex * 3, 3),
                                                rawInput.AsSpan(27 * 2 + qIndex * 3, 3));
            for (int i = 0; i < _digits.Length; i++)
            {
                if (CharDifference(digitToCheck, _digits[i]) == 1)
                {
                    currentNumber[qIndex] = (char)(i + '0');
                    if(IsSumValid(currentNumber.ToString()))
                        deviations.Add(currentNumber.ToString());
                }
            }

            return deviations.Count switch
            {
                0 => parsedInput + " ILL",
                1 => deviations[0],
                _ => parsedInput + " AMB ['" + string.Join("', '", deviations) + "']"
            };
        }

        
        for(int i = 0; i < parsedInput.Length; i++)
        {
            currentNumber = new StringBuilder(parsedInput);
            digitToCheck = string.Concat(rawInput.AsSpan(i * 3, 3),
                                         rawInput.AsSpan(27 + i * 3, 3),
                                         rawInput.AsSpan(27 * 2 + i * 3, 3));
            for(int j = 0; j < _digits.Length; j++)
            {
                if (CharDifference(digitToCheck, _digits[j]) == 1)
                {
                    currentNumber[i] = (char)(j + '0');
                    if(IsSumValid(currentNumber.ToString()))
                        deviations.Add(currentNumber.ToString());
                }
            }
        }

        return deviations.Count switch
        {
            0 => parsedInput + " ILL",
            1 => deviations[0],
            > 1 => parsedInput + " AMB ['" + string.Join("', '", deviations) + "']",
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private int CharDifference(string input, string digit)
    {
        int count = 0;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] != digit[i])
                count++;
        }
        return count;
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
