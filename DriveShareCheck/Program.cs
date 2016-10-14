using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveShareCheck
{
    internal class Program
    {
        private static List<String> dip = new List<string>(); //dip like desktop.ini paths
        private static readonly string startpath = $@"C:\Users\{Environment.UserName}\Google Drive";

        private static void Main(string[] args)
        {
            Console.WriteLine($"Looking for Drive at {startpath}");
            IterateDirectories(startpath);
            Console.WriteLine($"Found {dip.Count} shared Files/Directories:\n");
            foreach (var path in dip)
            {
                Console.WriteLine(path);
            }
            Console.ReadKey();
        }

        //Recursive Iteration
        private static void IterateDirectories(string path)
        {
            //Read all Directories and Files of current directory
            var dir = Directory.EnumerateDirectories(path);
            var files = Directory.EnumerateFiles(path);

            //Check if it's not the main drive directory, else check if it has a desktop.ini file
            if (path != startpath && files.Any(a => a.EndsWith("desktop.ini")))
            {
                dip.Add(path);
                return;
            }

            //Iterate and execute recursion
            foreach (var d in dir)
            {
                IterateDirectories(d);
            }
        }
    }
}