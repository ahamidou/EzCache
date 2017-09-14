using System;

namespace CacheApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Provide valid text file path
            string filePath = @"c:\temp\cache-file.txt";
            var fileContentProvider = new FileContentProvider(filePath);
            while (Console.ReadLine() == "r")
            {
                Console.Clear();
                var fileContents = fileContentProvider.GetContents();
                Console.WriteLine(fileContents);
            }
        }
    }
}
