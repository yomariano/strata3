using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = @"C:\devTest\test2.txt";
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName);
            List<string> linesSelec = new List<string>();
            foreach (string line in File.ReadAllLines(path))
            {
                if (line.Contains("200") && line.Contains("GET") && line.Contains(".gif")) {
                    var selectedLine = line.Split(' ').ToList().Where(s => s.Contains(".gif")).FirstOrDefault()?.Split('/').Last();
                    linesSelec.Add(selectedLine);
                }
            }

            File.WriteAllLinesAsync($"ref_{Path.GetFileName(path)}", linesSelec
                .Where(gif => gif != null)
                .Distinct());

        }
    }
}
