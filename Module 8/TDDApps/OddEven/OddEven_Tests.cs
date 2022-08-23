namespace OddEven;

public class OddEvenTests
{
    [Theory]
    [InlineData(-921834618, "Even")]
    [InlineData(-570258245, "Odd")]
    [InlineData(-38440691, "Odd")]
    [InlineData(-76781, "Odd")]
    [InlineData(76781, "76781")]
    [InlineData(24329, "24329")]
    [InlineData(38440691, "38440691")]
    [InlineData(519702546, "Even")]
    [InlineData(845176713, "Odd")]
    [InlineData(970082554, "Even")]
    public void ParseNumberTest(int number, string expectedResult)
    {
        Assert.Equal(expectedResult, OddEvenClass.Parse(number));
    }
    
    [Theory]
    [InlineData(-921834618, false)]
    [InlineData(-570258245, false)]
    [InlineData(-38440691, false)]
    [InlineData(-76781, false)]
    [InlineData(76781, true)]
    [InlineData(24329, true)]
    [InlineData(38440691, true)]
    [InlineData(519702546, false)]
    [InlineData(845176713, false)]
    [InlineData(970082554, false)]
    public void IsPrimeTest(int number, bool expectedResult)
    {
        Assert.Equal(expectedResult, OddEvenClass.IsPrime(number));
    }
    
}