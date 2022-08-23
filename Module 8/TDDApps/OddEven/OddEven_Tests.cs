namespace OddEven;

public class OddEvenTests
{
    [Theory]
    [InlineData(1, "Odd")]
    [InlineData(2, "2")]
    [InlineData(13, "13")]
    [InlineData(24, "Even")]
    [InlineData(35, "Odd")]
    [InlineData(46, "Even")]
    [InlineData(57, "Odd")]
    [InlineData(68, "Even")]
    [InlineData(79, "79")]
    [InlineData(90, "Even")]
    public void ParseNumberTest(int number, string expectedResult)
    {
        Assert.Equal(expectedResult, OddEvenClass.Parse(number));
    }
    
    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(13, true)]
    [InlineData(24, false)]
    [InlineData(35, false)]
    [InlineData(46, false)]
    [InlineData(57, false)]
    [InlineData(68, false)]
    [InlineData(79, true)]
    [InlineData(90, false)]
    public void IsPrimeTest(int number, bool expectedResult)
    {
        Assert.Equal(expectedResult, OddEvenClass.IsPrime(number));
    }
    
}