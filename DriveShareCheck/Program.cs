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
        private static string startpath = $@"C:\Users\{Environment.UserName}\Google Drive";

        private static void Main(string[] args)
        {
            IterateDirectories(startpath);
            foreach (var path in dip)
            {
                Console.WriteLine(path);
            }
            Console.ReadKey();
        }

        private static void IterateDirectories(string path)
        {
            var dir = Directory.EnumerateDirectories(path);
            var files = Directory.EnumerateFiles(path);
            if (path != startpath && files.Any(a => a.EndsWith("desktop.ini")))
            {
                dip.Add(path);
                return;
            }
            foreach (var d in dir)
            {
                IterateDirectories(d);
            }
        }
    }
}