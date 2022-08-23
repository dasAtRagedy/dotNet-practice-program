namespace OddEven;

public class OddEvenClass
{
    // TODO: Create a new method to check Odd/Even/Prime of a single supplied method (wtf)
    public void PrintNumbers()
    {
        for(int i = 1; i <= 100; i++)
            Console.WriteLine(Parse(i));
    }
    public void PrintNumbers(int n, int m)
    {
        for(int i = n; i <= m; i++)
            Console.WriteLine(Parse(i));
    }
    
    
    public static string Parse(int num)
    {
        if (IsPrime(num))
            return num.ToString();
        return num % 2 == 0 ? "Even" : "Odd";
    }

    public static bool IsPrime(int num)
    {
        if(num <= 1)
            return false;
        for (int i = 2; i < num; i++)
            if (num % i == 0)
                return false;
        return true;
    }
}