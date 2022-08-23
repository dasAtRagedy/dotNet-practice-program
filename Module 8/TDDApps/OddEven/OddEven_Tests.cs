namespace OddEven;

public class OddEvenTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(5, 5)]
    [InlineData(27, 27)]
    [InlineData(59, 59)]
    [InlineData(100, 100)]
    public void ParseNumberTest(int number, int expectedResult)
    {
        Assert.Equal(expectedResult, OddEvenClass.Parse(number));
    }
}