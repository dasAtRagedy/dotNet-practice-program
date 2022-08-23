namespace OddEven;

public class OddEvenTests
{
    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "Even")]
    [InlineData(5, "5")]
    [InlineData(6, "Even")]
    [InlineData(27, "27")]
    [InlineData(28, "Even")]
    [InlineData(54, "Even")]
    [InlineData(59, "59")]
    [InlineData(99, "99")]
    [InlineData(100, "Even")]
    public void ParseNumberTest(int number, string expectedResult)
    {
        Assert.Equal(expectedResult, OddEvenClass.Parse(number));
    }
}