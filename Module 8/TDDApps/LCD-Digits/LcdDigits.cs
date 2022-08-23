namespace LCD_Digits;

public class LcdDigits
{
    private string[,] _resultNumbers = new string[10, 3] // numbers from 0 to 9
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
}