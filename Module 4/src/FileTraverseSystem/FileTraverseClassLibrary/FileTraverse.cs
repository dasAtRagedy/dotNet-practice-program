using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace FileTraverseClassLibrary
{
    public class FileTraverse
    {
        private readonly Regex _rx = new Regex(".*");
        private string _path;
        private readonly DirectoryInfo _dir;

        public delegate bool NameFilterDelegate(string name);

        public event EventHandler OnSearchStarted;
        public event EventHandler OnSearchFinished;
        public event EventHandler OnFileFound;
        public event EventHandler OnDirectoryFound;
        public event EventHandler OnFilteredFileFound;
        public event EventHandler OnFilteredDirectoryFound;
        
        public FileTraverse(string path)
        {
            _path = path;
            _dir = new DirectoryInfo(path);
        }
        public FileTraverse(string path, string searchPattern)
        {
            _path = path;
            _dir = new DirectoryInfo(path);
            _rx = new Regex(searchPattern);
        }

        public static void OnSearchStartedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Search started!");
        }
        public static void OnSearchFinishedEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Search finished!");
        }
        public static void OnFileFoundEvent(object sender, EventArgs e)
        {
            Console.WriteLine("File found!");
        }
        public static void OnDirectoryFoundEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Directory found!");
        }
        public static void OnFilteredFileFoundEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Filtered file found!");
        }
        public static void OnFilteredDirectoryFoundEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Filtered directory found!");
        }
        
        public bool RegexFilter(string name)
        {
            return _rx.IsMatch(name);
        }
        
        public IEnumerable<string> SearchFiles(NameFilterDelegate filter)
        {
            OnSearchStarted?.Invoke(this, EventArgs.Empty);
            foreach (var f in _dir.EnumerateFiles("*", SearchOption.AllDirectories))
            {
                OnFileFound?.Invoke(this, EventArgs.Empty);
                if (!filter(f.Name)) continue;
                OnFilteredFileFound?.Invoke(this, EventArgs.Empty);
                yield return f.FullName;
            }
        }
        
        public IEnumerable<string> SearchDirectories(NameFilterDelegate filter)
        {
            OnSearchStarted?.Invoke(this, EventArgs.Empty);
            foreach (var d in _dir.EnumerateDirectories("*", SearchOption.AllDirectories))
            {
                OnDirectoryFound?.Invoke(this, EventArgs.Empty);
                if (!filter(d.Name)) continue;
                OnFilteredDirectoryFound?.Invoke(this, EventArgs.Empty);
                yield return d.FullName;
            }
            OnSearchFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}
