namespace LCD_Digits;

public class LcdDigits_Tests
{
    [Theory]
    [InlineData(0, "._.\r\n|.|\r\n|_|")]
    [InlineData(5, "._.\r\n|_.\r\n._|")]
    [InlineData(9, "._.\r\n|_|\r\n..|")]
    public void PrintDigitTest(int num, string result)
    {
        var lcdDigits = new LcdDigits();
        Assert.Equal(result, lcdDigits.GetDigit(num));
    }
}