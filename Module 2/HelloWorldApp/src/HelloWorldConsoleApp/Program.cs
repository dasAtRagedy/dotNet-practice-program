using HelloWorldLibrary;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write(HelloWorldTextFormatter.FormatText(args[0]));
        }
        catch (IndexOutOfRangeException ex)
        {
            throw new IndexOutOfRangeException(ex.Message);
        }
    }
}
