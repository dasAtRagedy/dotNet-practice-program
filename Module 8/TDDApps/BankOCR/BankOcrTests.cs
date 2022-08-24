namespace BankOCR;

public class BankOcrTests
{
    [Theory]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "| || || || || || || || || |"+
                "|_||_||_||_||_||_||_||_||_|", "000000000")]
    [InlineData("                           "+
                "  |  |  |  |  |  |  |  |  |"+
                "  |  |  |  |  |  |  |  |  |", "111111111")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                " _| _| _| _| _| _| _| _| _|"+
                "|_ |_ |_ |_ |_ |_ |_ |_ |_ ", "222222222")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                " _| _| _| _| _| _| _| _| _|"+
                " _| _| _| _| _| _| _| _| _|", "333333333")]
    [InlineData("                           "+
                "|_||_||_||_||_||_||_||_||_|"+
                "  |  |  |  |  |  |  |  |  |", "444444444")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "|_ |_ |_ |_ |_ |_ |_ |_ |_ "+
                " _| _| _| _| _| _| _| _| _|", "555555555")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "|_ |_ |_ |_ |_ |_ |_ |_ |_ "+
                "|_||_||_||_||_||_||_||_||_|", "666666666")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "  |  |  |  |  |  |  |  |  |"+
                "  |  |  |  |  |  |  |  |  |", "777777777")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "|_||_||_||_||_||_||_||_||_|"+
                "|_||_||_||_||_||_||_||_||_|", "888888888")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "|_||_||_||_||_||_||_||_||_|"+
                " _| _| _| _| _| _| _| _| _|", "999999999")]
    public void ParseTest(string input, string expected)
    {
        var bankOcr = new BankOcr();
        var result = bankOcr.Parse(input);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("000000000", true)]
    [InlineData("000000001", false)]
    [InlineData("999999999", false)]
    [InlineData("999878999", true)]
    public void IsSumValidTest(string input, bool expected)
    {
        var result = BankOcr.IsSumValid(input);
        Assert.Equal(expected, result);
    }
}