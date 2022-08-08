using NUnit.Framework;

namespace FileTraverseClassLibrary.FileTraverseTests
{
    public class Tests
    {
        [Test]
        public void Raise_Event_When_File_Found()
        {
            const string path = @"C:\TestingFolder";
            var explorer = new FileTraverse(path);
            var filterDelegate = new FileTraverse.NameFilterDelegate(explorer.RegexFilter);
            
            explorer.OnSearchStarted += FileTraverse.OnSearchStartedEvent;
            explorer.OnSearchFinished += FileTraverse.OnSearchFinishedEvent;
        }
    }
}