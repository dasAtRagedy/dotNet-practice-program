namespace OddEven;

public class OddEvenTests
{
    [Theory]
    [InlineData(1, "Odd")]
    [InlineData(2, "Even")]
    [InlineData(5, "Odd")]
    [InlineData(6, "Even")]
    [InlineData(27, "Odd")]
    [InlineData(28, "Even")]
    [InlineData(54, "Even")]
    [InlineData(59, "Odd")]
    [InlineData(99, "Odd")]
    [InlineData(100, "Even")]
    public void ParseNumberTest(int number, string expectedResult)
    {
        Assert.Equal(expectedResult, OddEvenClass.Parse(number));
    }
}