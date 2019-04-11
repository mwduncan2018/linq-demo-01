using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\";
            ShowLargeFilesWithoutLinq(path);
            Console.WriteLine("****************************************************");
            Console.WriteLine("****************************************************");
            Console.WriteLine("****************************************************");
            ShowLargeFilesWithLinq_01(path);
            Console.WriteLine("****************************************************");
            Console.WriteLine("****************************************************");
            Console.WriteLine("****************************************************");
            ShowLargeFilesWithLinq_02(path);
            Console.ReadKey();
        }

        private static void ShowLargeFilesWithLinq_01(string path)
        {
            var query = from file in new DirectoryInfo(path).GetFiles()
                        orderby file.Length descending
                        select file;
            foreach (var file in query.Take(6))
            {
                Console.WriteLine($"{file.Length} : {file.Name}");
            }
        }

        private static void ShowLargeFilesWithLinq_02(string path)
        {
            var query = new DirectoryInfo(path).GetFiles()
                .OrderByDescending(x => x.Length)
                .Take(6);
            foreach (var file in query.Take(6))
            {
                Console.WriteLine($"{file.Length} : {file.Name}");
            }
        }

        private static void ShowLargeFilesWithoutLinq(string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles();
            Array.Sort(files, new FileInfoComparer());
            
            for (int i = 0; i < 6; i++)
            {
                FileInfo file = files[i];
                Console.WriteLine($"{file.Length} : {file.Name}");
            }
        }

        public class FileInfoComparer : IComparer<FileInfo>
        {
            public int Compare(FileInfo x, FileInfo y)
            {
                return y.Length.CompareTo(x.Length);
            }
        }
    }
}
