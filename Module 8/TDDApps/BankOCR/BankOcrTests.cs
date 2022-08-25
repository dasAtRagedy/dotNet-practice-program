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
    [InlineData("|_ |_ |_ |_ |_ |_ |_ |   _ "+
                "|_||_||_||_||_||_||_||_||_|"+
                " _| _| _| _| _| _| _| _| _|", "????????9")]
    public void ParseTest(string input, string expected)
    {
        var bankOcr = new BankOcr();
        var result = bankOcr.Parse(input);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(" _  _  _  _  _  _  _  _    "+
                "| || || || || || || ||_   |"+
                "|_||_||_||_||_||_||_| _|  |", "000000051")]
    [InlineData("    _  _  _  _  _  _     _ "+
                "|_||_|| || ||_   |  |  | _ "+
                "  | _||_||_||_|  |  |  | _|", "49006771? ILL")]
    [InlineData("    _  _     _  _  _  _  _ "+
                "  | _| _||_| _ |_   ||_||_|"+
                "  ||_  _|  | _||_|  ||_| _ ", "1234?678? ILL")]
    public void ParseWithCodeTest(string input, string expected)
    {
        var bankOcr = new BankOcr();
        var result = bankOcr.ParseWithCode(input);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("                           "+
                "  |  |  |  |  |  |  |  |  |"+
                "  |  |  |  |  |  |  |  |  |", "711111111")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "  |  |  |  |  |  |  |  |  |"+
                "  |  |  |  |  |  |  |  |  |", "777777177")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                " _|| || || || || || || || |"+
                "|_ |_||_||_||_||_||_||_||_|", "200800000")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                " _| _| _| _| _| _| _| _| _|"+
                " _| _| _| _| _| _| _| _| _|", "333393333")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "|_||_||_||_||_||_||_||_||_|"+
                "|_||_||_||_||_||_||_||_||_|", "888888888 AMB ['888886888', '888888988', '888888880']")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "|_ |_ |_ |_ |_ |_ |_ |_ |_ "+
                " _| _| _| _| _| _| _| _| _|", "555555555 AMB ['559555555', '555655555']")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "|_ |_ |_ |_ |_ |_ |_ |_ |_ "+
                "|_||_||_||_||_||_||_||_||_|", "666666666 AMB ['686666666', '666566666']")]
    [InlineData(" _  _  _  _  _  _  _  _  _ "+
                "|_||_||_||_||_||_||_||_||_|"+
                " _| _| _| _| _| _| _| _| _|", "999999999 AMB ['899999999', '993999999', '999959999']")]
    [InlineData("    _  _  _  _  _  _     _ "+
                "|_||_|| || ||_   |  |  ||_ "+
                "  | _||_||_||_|  |  |  | _|", "490067715 AMB ['490867715', '490067115', '490067719']")]
    [InlineData("    _  _     _  _  _  _  _ "+
                " _| _| _||_||_ |_   ||_||_|"+
                "  ||_  _|  | _||_|  ||_| _|", "123456789")]
    [InlineData(" _     _  _  _  _  _  _    "+
                "| || || || || || || ||_   |"+
                "|_||_||_||_||_||_||_| _|  |", "000000051")]
    [InlineData("    _  _  _  _  _  _     _ "+
                "|_||_|| ||_||_   |  |  | _ "+
                "  | _||_||_||_|  |  |  | _|", "490867715")]
    public void ParseWithCodeAndDeviationsTest(string input, string expected)
    {
        var bankOcr = new BankOcr();
        var result = bankOcr.ParseWithCodeAndDeviations(input);
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