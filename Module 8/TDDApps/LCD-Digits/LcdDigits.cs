namespace LCD_Digits;

public class LcdDigits
{
    private string[,] _resultNumbers = new string[10, 3] // digits from 0 to 9
    {
        { "._.", "|.|", "|_|"},
        { "...", "..|", "..|"},
        { "._.", "._|", "|_."},
        { "._.", "._|", "._|"},
        { "...", "|_|", "..|"},
        { "._.", "|_.", "._|"},
        { "._.", "|_.", "|_|"},
        { "._.", "..|", "..|"},
        { "._.", "|_|", "|_|"},
        { "._.", "|_|", "..|"}
    };

    public string GetDigit(int digit)
    {
        return _resultNumbers[digit, 0] + Environment.NewLine +
               _resultNumbers[digit, 1] + Environment.NewLine +
               _resultNumbers[digit, 2];
    }
    

    public string GetDigits(string num)
    {
        string result = "";
        for(int j = 0; j < 3; j++)
        {
            for(int i = 0; i < num.Length; i++)
            {
                result += _resultNumbers[num[i] - '0', j];
                if(i != num.Length - 1)
                    result += " ";
            }
            if(j != 2)
                result += Environment.NewLine;
        }

        return result;
    }
}