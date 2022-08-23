namespace OddEven;

public class OddEvenClass
{
    public void PrintNumbers()
    {
        for(int i = 1; i <= 100; i++)
            Console.WriteLine(Parse(i));
    }
    public static int Parse(int num)
    {
        return num;
    }
}