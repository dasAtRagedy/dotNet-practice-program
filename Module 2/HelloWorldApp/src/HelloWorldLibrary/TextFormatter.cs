namespace HelloWorldLibrary
{
    public class HelloWorldTextFormatter
    {
        public static string FormatText(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return "";
            }
            else
            {
                return "Hello, " + s;
            }
        }
    }
}