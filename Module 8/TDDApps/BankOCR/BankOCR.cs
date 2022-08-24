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
        for (int i = 0; i < 9; i++)
        {
            for(int j = 0; j < _digits.Length; j++)
            {
                var currentDigit = input.Substring(i*3, 3) + 
                                    input.Substring(27+i*3, 3) +
                                    input.Substring(27*2+i*3, 3);
                if (currentDigit == _digits[j])
                {
                    result += j.ToString();
                    break;
                }
            }
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
