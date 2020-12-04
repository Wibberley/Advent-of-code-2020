using System;
using System.Collections.Generic;
using System.IO;

namespace Utilities
{
    public static class FileReader
    {
        public static List<string> ReadFileLines(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return new List<string>(lines);
        }

        public static string ReadFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}