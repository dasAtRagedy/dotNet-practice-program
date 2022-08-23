namespace LCD_Digits;

public class LcdDigits_Tests
{
    [Theory]
    [InlineData(0, "._.\r\n"+
                   "|.|\r\n"+
                   "|_|")]
    [InlineData(5, "._.\r\n"+
                   "|_.\r\n"+
                   "._|")]
    [InlineData(9, "._.\r\n"+
                   "|_|\r\n"+
                   "..|")]
    public void PrintDigitTest(int num, string result)
    {
        var lcdDigits = new LcdDigits();
        Assert.Equal(result, lcdDigits.GetDigit(num));
    }
    
    [Theory]
    [InlineData("910", "._. ... ._.\r\n"+
                       "|_| ..| |.|\r\n"+
                       "..| ..| |_|")]
    [InlineData("0123456789", "._. ... ._. ._. ... ._. ._. ._. ._. ._.\r\n"+
                              "|.| ..| ._| ._| |_| |_. |_. ..| |_| |_|\r\n"+
                              "|_| ..| |_. ._| ..| ._| |_| ..| |_| ..|")]
    public void PrintDigitsTest(string num, string result)
    {
        var lcdDigits = new LcdDigits();
        Assert.Equal(result, lcdDigits.GetDigits(num));
    }
}