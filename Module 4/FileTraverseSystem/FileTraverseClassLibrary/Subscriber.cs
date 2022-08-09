using System;

namespace FileTraverseClassLibrary
{
    public class Subscriber
    {
        public void OnSearchingEvent(object source, EventArgs e)
        {
            Console.WriteLine("Started the search...");
        }
        public void OnSearchedEvent(object source, EventArgs e)
        {
            Console.WriteLine("Search has been ended...");
        }
    }
}