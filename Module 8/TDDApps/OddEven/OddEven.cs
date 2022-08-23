namespace OddEven;

public class OddEvenClass
{
    public void PrintNumbers()
    {
        for(int i = 1; i <= 100; i++)
            Console.WriteLine(Parse(i));
    }
    public static string Parse(int num)
    {
        if (num % 2 == 0)
            return "Even";
        return "Odd";
    }
}