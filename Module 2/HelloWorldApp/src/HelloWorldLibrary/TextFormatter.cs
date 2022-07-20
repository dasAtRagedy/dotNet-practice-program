namespace HelloWorldLibrary
{
    public class HelloWorldTextFormatter
    {
        public static string FormatText(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? string.Empty : System.DateTime.Now.ToString("yyyy-MM-dd") + " Hello, " + s;
        }
    }
}