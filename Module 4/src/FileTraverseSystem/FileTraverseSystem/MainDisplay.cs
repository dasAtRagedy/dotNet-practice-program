using FileTraverseClassLibrary;

const string path = @"C:\TestingFolder";
var explorer = new FileTraverse(path);
var filterDelegate = new FileTraverse.NameFilterDelegate(explorer.RegexFilter);

explorer.OnSearchStarted += FileTraverse.OnSearchStartedEvent;
explorer.OnSearchFinished += FileTraverse.OnSearchFinishedEvent;

foreach(var file in explorer.SearchFiles(filterDelegate))
    Console.WriteLine(file);

Console.WriteLine();

foreach(var dir in explorer.SearchDirectories(filterDelegate))
    Console.WriteLine(dir);


